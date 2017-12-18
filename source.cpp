
#include <iostream>
#include "Functions.h"


using namespace std;

inline void p1() {
	int a = 10,
		b = 20;

	printf("a = %i\nb = %i", a, b);

	swap(&a, &b);

	printf("a = %i\nb = %i", a, b);
}

inline void p2() {

	int a[10] = { 1,2,3,4,5,6,7,8,9,10 };
	int b[5] = { 11,12,13,14,15 };

	int* ptr_a = a;
	int* ptr_b = b;

	swapArrays(&ptr_a, &ptr_b);

	printArr(ptr_a, 5);
	cout << endl;
	printArr(ptr_b, 10);
	cout << endl;
}

inline void p3() {
	unsigned size = 20;

	int a[] = { 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20 };
	int* ptr_a = a;

	filterArr(ptr_a, size);
	printArr(ptr_a, size);

}

int main() {
	system("color 2");

	p2();
	p3();

	system("pause");
	return 0;
}

/*
	int a = 1;
	int b = 2;
	double c = 3.12;

	int* pA = &a;
	int* pB = &b;
	double* pC = &c;

	void* arr[3] = {pA, pB, pC};

	cout << *(int *)arr[0] << endl;
	cout << *(int *)arr[1] << endl;
	cout << *(double *)arr[2] << endl;

*/