

#include <iostream>

using namespace std;

/*
	4 x Homework (+- 8 ����)
		�������� � �������
			���� ������
	������
		-��� 50% ��������
			����� 2 ������
		-��� 2 ������ (���� ��������� � �������)
	���������
		-������
		-1%
		-����� �����
	������ (������)
		-��� �����
	������ �� ����������
		-40% ���
		-40% ������
		-10% ���������
		-10% ������
		-���� �����
*/

class Matrix {
public:

	//////////////////////

	/////////////////////

	Matrix(unsigned rows, unsigned cols) {
		arr = new(nothrow) double*[rows];
		if (!arr) {
			cerr << "Can't alloc\n";
			return;
		}

		for (unsigned i = 0; i < rows; ++i) {
			arr[i] = new(nothrow) double[cols];
			if (!arr[i]) {
				cerr << "Can't alloc\n";
				for (unsigned j = 0; j < i; ++j)
					delete[] arr[j];
				return;
			}
		}
	}

	///	��������:
	///		�������� �� ������ � �������
	///		�����������
	///		�������
	///		
	///

private:
	
	double** arr;

	unsigned rowSize;
	unsigned colSize;
};

int main() {

	
	return 0;
}