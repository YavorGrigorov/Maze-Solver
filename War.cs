using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    class WarGame
    {
        class Player
        {
            //Tova e za igracha da slaga ime
            public Player()
            {
                
                printl("Player name:");
                Name = Console.ReadLine();
                SetDeck(0);
            }

            //Tova e za nas da moje da napravim teste
            public Player(string name, int cardCount)
            {
                Name = name;
                SetDeck(cardCount);
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
                printl($"Called player {Name}'s destructor.");
                Deck = null;
                Name = null;
            }

            private string Name;
            
            //Teq trite se podrazbira
            public bool CheckForCardInDeck(string card)
            {
                return Deck[card] < 1;
            }

            public void AddCardToDeck(string card)
            {
                Deck[card]++;
            }

            public void RemoveCardFromDeck(string card)
            {
                Deck[card]--;
            }
        }

        

        //Razdavaneto na kartite. Vzima i testeto za spravka i popravka :D
        static void DistibuteCards(Player pl1, Player pl2, Player deck)
        {
            Random rndCard = new Random();

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

            printl("===========================================");
            pl1.ShowDeckAndName();
            printl("===========================================");
            pl2.ShowDeckAndName();
            printl("===========================================");
            deck.ShowDeckAndName();

        }

        //printLine func
        static void printl(string output)
        {
            Console.WriteLine(output);
        }
    }
}