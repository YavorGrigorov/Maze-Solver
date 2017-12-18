#pragma once

#include <iostream>

void swap(int* a, int* b);

//if both are equal in size
void swapArrays(int** a1, int** a2);

void printArr(int* arr, unsigned size);

//extarcts elements on 2n postions only
void filterArr(int* arr, unsigned& size);