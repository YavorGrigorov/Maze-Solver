using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    class WarGame
    {
        static Random rndCard = new Random();
        static Random rndCard2 = new Random();

        class Player
        {
            //Tova e za igracha da slaga ime
            public Player()
            {
                
                printl("Player name:");
                Name = Console.ReadLine();
                SetDeck(0);
                cardsInDeck = 0;
            }

            //Tova e za nas da moje da napravim teste
            public Player(string name, int cardCount)
            {
                Name = name;
                SetDeck(cardCount);
                cardsInDeck = 0;
            }

            //suzdava testetata
            private Dictionary<string, int> Deck = new Dictionary<string, int>();
            private void SetDeck(int cardCount)
            {
                for (int card = 2; card < 15; card++)
                {
                    switch (card)
                    {
                        case 11:
                            Deck.Add("Jack", cardCount);
                            break;
                        case 12:
                            Deck.Add("Queen", cardCount);
                            break;
                        case 13:
                            Deck.Add("King", cardCount);
                            break;
                        case 14:
                            Deck.Add("Ace", cardCount);
                            break;
                        default:
                            Deck.Add(card + "", cardCount);
                            break;
                    }
                }
            }

            public void ShowDeckAndName()
            {
                printl($"Player {Name} has:");
                printl(string.Join(" ", Deck));
            }

            ~Player()
            {
                Deck = null;
                Name = null;
            }

            private string Name;
            private int points;
            public int currentCard;
            public List<int> currentCardsMore = new List<int>();
            private int cardsInDeck;

            public int GetPoints()
            {
                return points;
            }

            public string GetName()
            {
                return Name;
            }

            public int GetCardCount()
            {
                return cardsInDeck;
            }

            public void AddCardsToCurr(int[] adding)
            {
                foreach(int card in adding)
                {
                    currentCardsMore.Add(card);
                }
            }

            public void AddPoints(int pointsToAdd)
            {
                points += pointsToAdd;
            }
            
            //Teq trite se podrazbira
            public bool CheckForCardInDeck(string card)
            {
                return Deck[card] < 1;
            }

            public bool CheckForCardsInDeck()
            {
                foreach(string card in Deck.Keys)
                {
                    if (Deck[card] > 0) return false;
                }
                return true;
            }

            public void AddCardToDeck(string card)
            {
                Deck[card]++;
                cardsInDeck++;
            }

            public void RemoveCardFromDeck(string card)
            {
                Deck[card]--;
                cardsInDeck--;
            }
        }

        

        //Razdavaneto na kartite. Vzima i testeto za spravka i popravka :D
        static void DistibuteCards(Player pl1, Player pl2, Player deck)
        {
            for (int cardNum = 0; cardNum < 52; cardNum += 2)
            {
            Player1:
                int card = rndCard.Next(2, 15);

                if (deck.CheckForCardInDeck
                        (GetCardName(card)))
                    goto Player1;

                pl1.AddCardToDeck(GetCardName(card));
                deck.RemoveCardFromDeck(GetCardName(card));

            Player2:
                card = rndCard.Next(2, 15);

                if (deck.CheckForCardInDeck
                        (GetCardName(card)))
                    goto Player2;

                pl2.AddCardToDeck(GetCardName(card));
                deck.RemoveCardFromDeck(GetCardName(card));
            }
        }

        //Tova Prevejda ot int v string kartata
        static string GetCardName(int cardNum)
        {
            switch (cardNum)
            {
                case 11:
                    return "Jack";
                case 12:
                    return "Queen";
                case 13:
                    return "King";
                case 14:
                    return "Ace";
                default:
                    return $"{cardNum}";
            }
        }

        static void Main(string[] args)
        {
            Player deck = new Player("deck", 4);
            Player pl1 = new Player("Ivan", 0);
            Player pl2 = new Player("Peter", 0);

            DistibuteCards(pl1, pl2, deck);
            
            for (; ;)
            {
                Player1:
                pl1.currentCard = rndCard.Next(2, 14);

                if (pl1.CheckForCardInDeck
                        (GetCardName(pl1.currentCard)))
                {
                    System.Threading.Thread.Sleep(250);
                    goto Player1;
                }

            Player2:
                pl2.currentCard = rndCard2.Next(2, 14);

                if (pl2.CheckForCardInDeck
                        (GetCardName(pl2.currentCard)))
                {
                    System.Threading.Thread.Sleep(250);
                    goto Player2;
                }
                    

                printl("===========================================");
                printl($"{pl1.GetName()} has a {GetCardName(pl1.currentCard)}");
                printl($"{pl2.GetName()} has a {GetCardName(pl2.currentCard)}");
                printl("===========================================");

                if (pl1.currentCard > pl2.currentCard)
                {
                    pl1.AddPoints(1);

                    pl1.AddCardToDeck(GetCardName(pl2.currentCard));
                    pl2.RemoveCardFromDeck(GetCardName(pl2.currentCard));

                    printl("===========================================");
                    printl($"{pl1.GetName()} won with a {GetCardName(pl1.currentCard)}");
                    printl("===========================================");
                    printl($"Current score:\n{pl1.GetName()} has {pl1.GetPoints()} points\n" +
                        $"{pl2.GetName()} has {pl2.GetPoints()} points\n" +
                        $"Card count:\n" +
                        $"{pl1.GetName()} has {pl1.GetCardCount()} cards\n" +
                        $"{pl2.GetName()} has {pl2.GetCardCount()} cards");

                    System.Threading.Thread.Sleep(500);
                }
                else if(pl1.currentCard == pl2.currentCard)
                {
                    printl("WAAAAGH!!!");

                    pl1.currentCardsMore.Add(pl1.currentCard);
                    pl2.currentCardsMore.Add(pl2.currentCard);
                    for(int k = 1; ; k++)
                    {
                        int[] pl1Cards = new int[3];
                        int[] pl2Cards = new int[3];

                        for (int i = 0; i < 3; i++)
                        {
                            pl1Cards[i] = rndCard.Next(2, 14);
                            pl2Cards[i] = rndCard2.Next(2, 14);
                        }

                        pl1.AddCardsToCurr(pl1Cards);
                        pl2.AddCardsToCurr(pl2Cards);

                        if (pl1Cards[2] > pl2Cards[2])
                        {
                            pl1.AddPoints(3 * k);

                            foreach (int card in pl2.currentCardsMore)
                            {
                                pl1.AddCardToDeck(GetCardName(card));
                                pl2.RemoveCardFromDeck(GetCardName(card));
                            }
                            
                            pl1.currentCardsMore.Clear();
                            pl2.currentCardsMore.Clear();

                            printl("===========================================");
                            printl($"{pl1.GetName()} won.");
                            printl("===========================================");
                            printl($"Current score:\n{pl1.GetName()} has {pl1.GetPoints()} points\n" +
                                $"{pl2.GetName()} has {pl2.GetPoints()} points\n" +
                                $"Card count:\n" +
                                $"{pl1.GetName()} has {pl1.GetCardCount()} cards\n" +
                                $"{pl2.GetName()} has {pl2.GetCardCount()} cards");

                            System.Threading.Thread.Sleep(500);

                            break;
                        }
                        else if (pl1Cards[2] < pl2Cards[2])
                        {
                            pl2.AddPoints(3 * k);

                            foreach (int card in pl1.currentCardsMore)
                            {
                                pl2.AddCardToDeck(GetCardName(card));
                                pl1.RemoveCardFromDeck(GetCardName(card));
                            }

                            pl1.currentCardsMore.Clear();
                            pl2.currentCardsMore.Clear();

                            printl("===========================================");
                            printl($"{pl2.GetName()} won.");
                            printl("===========================================");
                            printl($"Current score:\n{pl1.GetName()} has {pl1.GetPoints()} points\n" +
                                $"{pl2.GetName()} has {pl2.GetPoints()} points\n" +
                                $"Card count:\n" +
                                $"{pl1.GetName()} has {pl1.GetCardCount()} cards\n" +
                                $"{pl2.GetName()} has {pl2.GetCardCount()} cards");

                            System.Threading.Thread.Sleep(500);

                            break;
                        }
                    }
                }
                else
                {
                    pl2.AddPoints(1);

                    pl2.AddCardToDeck(GetCardName(pl1.currentCard));
                    pl1.RemoveCardFromDeck(GetCardName(pl1.currentCard));

                    printl("===========================================");
                    printl($"{pl2.GetName()} won.");
                    printl("===========================================");
                    printl($"Current score:\n{pl1.GetName()} has {pl1.GetPoints()} points\n" +
                        $"{pl2.GetName()} has {pl2.GetPoints()} points\n" +
                        $"Card count:\n" +
                        $"{pl1.GetName()} has {pl1.GetCardCount()} cards\n" +
                        $"{pl2.GetName()} has {pl2.GetCardCount()} cards");

                    System.Threading.Thread.Sleep(500);
                }

                if (pl1.CheckForCardsInDeck())
                {
                    printl($"{pl1.GetName()} lost the game.");
                    break;
                }
                else if (pl2.CheckForCardsInDeck())
                {
                    printl($"{pl2.GetName()} lost the game.");
                    break;
                }
            }


        }

        //printLine func
        static void printl(string output)
        {
            Console.WriteLine(output);
        }
    }
}