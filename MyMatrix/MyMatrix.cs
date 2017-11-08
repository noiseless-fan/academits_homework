using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_Lyulyaev
{
	public class MyMatrix
	{
		// поля и свойства
		private Vector[] matrix;

		public int Rows => matrix.Length;
		public int Columns => matrix[0].Length;
		public string SizeString => $"{Rows} x {Columns}";

		//a.	Получение размеров матрицы ----см. поля
		//b.	Получение и задание вектора-строки по индексу ----см. поля
		public Vector this[int row]
		{
			get
			{
				return new Vector(matrix[row]);
			}
			set
			{
				if (row < 0 || row >= Rows)
				{
					throw new ArgumentOutOfRangeException(nameof(row));
				}
				matrix[row] = new Vector(value);
			}
		}
		
		public double this[int row, int column]
		{
			get => matrix[row][column];
			set
			{
				if (row < 0 || row >= Rows || column < 0 || column >= Columns)
				{
					throw new ArgumentOutOfRangeException(nameof(row));
				}
				matrix[row][column] = value;
			}
		}
		//Конструкторы:
		//a.	Matrix(n, m) – матрица нулей размера nxm
		public MyMatrix(int rows, int columns)
		{
			if (rows <= 0 || columns <= 0)
			{
				throw new ArgumentOutOfRangeException("недопустимые размеры матрицы");
			}
			matrix = new Vector[rows];
			for(int i = 0; i < rows; i++)
			{
				matrix[i] = new Vector(columns);
			}
		}
		//b.	Matrix(Matrix) – конструктор копирования
		public MyMatrix(MyMatrix copyFrom)
		{
			matrix = new Vector[copyFrom.Rows];
			for (int i = 0; i < Rows; i++)
			{
				matrix[i] = new Vector(copyFrom[i]);
			}
		}
		//c.	Matrix(double[][]) – из двумерного массива
		public MyMatrix(double[][] arr)
		{
			if (arr.Rank < 1 || arr.Length == 0 || arr == null)
			{
				throw new ArgumentException(nameof(arr), "недопустимый массив для копирования.");
			}
			matrix = new Vector[arr.Length];
			for (int i = 0; i < matrix.Length; i++)
			{
				matrix[i] = new Vector(arr[i]);
			}
		}
		//d.	Matrix(Vector[]) – из массива векторов-строк
		public MyMatrix(Vector[] vector)
		{
			matrix = new Vector[vector.Length];
			for (int i = 0; i < matrix.Length; i++)
			{
				matrix[i] = new Vector(vector[i]);
			}
		}
		//Методы
		//c.	Получение вектора-столбца по индексу
		public Vector GetColumn(int index)
		{
			if (index < 0 || index >= Columns)
			{
				throw new ArgumentOutOfRangeException(nameof(index));
			}

			Vector column = new Vector(Rows);
			for (int i = 0; i < Rows; i++)
			{
				column[i] = this[i, index];
			}
			column.IsColumn = true;
			return column;
		}
		//d.	Транспонирование матрицы
		public MyMatrix Transpose()
		{
			MyMatrix transposed = new MyMatrix(Columns, Rows);
			for (int i = 0; i < Rows; i++)
			{
				for (int j = 0; j < Columns; j++)
				{
					transposed[j,i] = this[i,j];
				}
			}
			return transposed;
		}
		//e.	Умножение на скаляр
		public void MultiplyByScalar(double scalar)
		{
			foreach (Vector vec in matrix)
			{
				vec.MultiplyByScalar(scalar);
			}
		}
		//f.	Вычисление определителя матрицы
		public double Determinant()
		{
			if (Rows != Columns)
			{
				throw new ArgumentException();
			}

			var forDet = new MyMatrix(this);

			forDet.LadderView(out int sign);

			double detMatrix = 1;

			for (int i = 0; i < Rows; i++)
			{
				detMatrix *= forDet[i, i];
			}

			return detMatrix*sign;
		}

		private void LadderView(out int replaceCount)
		{
			replaceCount = 1;

			while (this[0, 0] == 0)
			{
				SwapRows(this, 0, new Random().Next(0, Rows));
				replaceCount *= -1;
			}

			for (int j = 0; j < Rows; j++)
			{
				for (int i = 1 + j; i < Rows; i++)
				{
					if (this[i, j] != 0)
					{
						this[i] = this[i].Addition(this[j].MultiplyByScalar(-this[i, j] / this[j, j]));
					}
				}
			}
		}

		private void SwapRows(MyMatrix matrix, int from, int to)
		{
			var temp = matrix[from];
			matrix[from] = matrix[to];
			matrix[to] = temp;
		}


		
		//h.	умножение матрицы на вектор
		public MyMatrix MultiplyByVector(Vector vector)
		{
			if (vector.IsColumn)
			{
				if (Columns != vector.Length)
				{
					throw new ArgumentException();
				}

				for (int i = 0; i < Rows; i++)
				{
					this[i] = this[i].MultiplyByVector(vector);
				}
				return this;
			}
			else if (Columns == 1 && Rows == vector.Length)
			{
				MyMatrix result = new MyMatrix(vector.Length, vector.Length);
				for (int i = 0; i < vector.Length; i++)
				{
					result[i] = new Vector(vector);
					result[i].MultiplyByScalar(this[i, 0]);
				}
				return result;
			}
			else 
			{
				throw new ArgumentException("несоотвествие аргументов произведения");
			}

		}
		//i.	Сложение матриц
		//j.	Вычитание матриц
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			foreach (Vector vector in matrix)
			{
				sb.Append(vector.ToString()).Append(Environment.NewLine);
			}
			return sb.ToString();
		}

		//Статические методы:
		//a.	Сложение матриц 
		//b.	Вычитание матриц
		//c.	Умножение матриц
	}
}
