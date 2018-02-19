

#include <iostream>

using namespace std;

/*
	4 x Homework (+- 8 общо)
		практиум и редовен
			няма защити
	Проект
		-мин 50% редовния
			около 2 месеца
		-има 2 защити (през семестъра и сесията)
	Контролно
		-дизайн
		-1%
		-Бонус точки
	Мнение (отново)
		-има време
	Оценка на практикума
		-40% дом
		-40% проект
		-10% контролно
		-10% мнение
		-Няма изпит
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

	///	Свойства:
	///		събиране на редове и колкони
	///		детермината
	///		пълнене
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