
#include "Functions.h";

void swap(int* a, int *b) {
	int temp = *a;
	*a = *b;
	*b = temp;
}

void swapArrays(int** a1, int** a2) {
	int* temp = *a1;
	*a1 = *a2;
	*a2 = temp;
}

void printArr(int* arr, unsigned size) {
	for (unsigned i = 0; i < size; ++i)
		printf("%i ", arr[i]);
}

void filterArr(int* arr, unsigned& size) {

	unsigned  write = 0;

	for (unsigned read = 0; read < size; ++read) {
		if (!(read % 2)) {
			arr[write] = arr[read];
			++write;
		}
	}

	std::cerr << "cerr\n";
	size = write;
}
