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
			if (arr.Rank != 2 || arr.Length == 0 || arr == null)
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
		
		//h.	умножение матрицы на вектор
		public void MultiplyByVector(Vector vector)
		{

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
