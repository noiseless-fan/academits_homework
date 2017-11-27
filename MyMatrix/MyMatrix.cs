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
		private Vector[] _rows;

		public int Rows => _rows.Length;
		public int Columns => _rows[0].Length;

		private static Random rnd = new Random();

		//a.	Получение размеров матрицы ----см. поля
		//b.	Получение и задание вектора-строки по индексу ----см. поля
		public Vector this[int row]
		{
			get
			{
				if (row < 0 || row >= Rows)
				{
					throw new ArgumentOutOfRangeException(nameof(row));
				}
				return new Vector(_rows[row]);
			}
			set
			{
				if (row < 0 || row >= Rows || value.Length > _rows[row].Length || value.Length < _rows[row].Length)
				{
					throw new ArgumentOutOfRangeException(nameof(row));
				}
				_rows[row] = new Vector(value);
			}
		}
		
		public double this[int row, int column]
		{
			get
			{
				if (row < 0 || row >= Rows || column < 0 || column >= Columns)
				{
					throw new ArgumentOutOfRangeException(nameof(row));
				}
				return _rows[row][column];
			}
			set
			{
				if (row < 0 || row >= Rows || column < 0 || column >= Columns)
				{
					throw new ArgumentOutOfRangeException(nameof(row));
				}
				_rows[row][column] = value;
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
			_rows = new Vector[rows];
			for(int i = 0; i < rows; i++)
			{
				_rows[i] = new Vector(columns);
			}
		}
		//b.	Matrix(Matrix) – конструктор копирования
		public MyMatrix(MyMatrix copyFrom)
		{
			_rows = new Vector[copyFrom.Rows];
			for (int i = 0; i < Rows; i++)
			{
				_rows[i] = new Vector(copyFrom[i]);
			}
		}
		//c.	Matrix(double[][]) – из двумерного массива
		public MyMatrix(double[,] arr)
		{
			if (arr.Length == 0)
			{
				throw new ArgumentException(nameof(arr), "недопустимый массив для копирования.");
			}

			_rows = new Vector[arr.GetLength(0)];
			for (int i = 0; i < _rows.Length; i++)
			{
				_rows[i] = new Vector(arr.GetLength(1));
				for (int j = 0; j < _rows[i].Length; j++)
				{
					_rows[i][j] = arr[i, j];
				}
			}
		}
		//d.	Matrix(Vector[]) – из массива векторов-строк
		public MyMatrix(Vector[] vector)
		{
			_rows = new Vector[vector.Length];

			int maxLength = vector[0].Length;
			foreach (Vector vec in vector)
			{
				maxLength = Math.Max(maxLength, vec.Length);
			}

			for (int i = 0; i < _rows.Length; i++)
			{
				_rows[i] = new Vector(maxLength).Addition(vector[i]);
			}
		}
		//Методы
		public void FillRandom()
		{
			for (int i = 0; i < this.Rows; i++)
			{
				for (int j = 0; j < this.Columns; j++)
				{
					this[i, j] = rnd.Next(-10, 10);
				}
			}
		}

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
		public void Transpose()
		{
			Vector[] transposed = new Vector[Columns];

			for (int i = 0; i < transposed.Length; i++)
			{
				transposed[i] = this.GetColumn(i);
			}
			_rows = transposed;
		}
		//e.	Умножение на скаляр
		public void MultiplyByScalar(double scalar)
		{
			foreach (Vector vec in _rows)
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

			int sign = forDet.LadderView();

			double detMatrix = 1;

			for (int i = 0; i < Rows; i++)
			{
				detMatrix *= forDet[i, i];
			}

			return detMatrix*sign;
		}

		private int LadderView()
		{
			int replaceCount = 1;

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
			return replaceCount;
		}

		private static void SwapRows(MyMatrix matrix, int from, int to)
		{
			var temp = matrix[from];
			matrix[from] = matrix[to];
			matrix[to] = temp;
		}

		//h.	умножение матрицы на вектор
		public Vector MultiplyByVector(Vector vector)
		{
			if (Columns != vector.Length)
			{
				throw new ArgumentException();
			}

			Vector result = new Vector(Rows);
			for (int i = 0; i < result.Length; i++)
			{
				result[i] = Sum(this[i].MultiplyByVector(vector));
			}
			return result;
		}

		private double Sum(Vector vector)
		{
			double sum = 0;
			for (int i = 0; i < vector.Length; i++)
			{
				sum += vector[i];
			}
			return sum;
		}
		//i.	Сложение матриц
		public MyMatrix Addition(MyMatrix second)
		{
			if (Rows != second.Rows || Columns != second.Columns)
			{
				throw new ArgumentException("размеры не совпадают");
			}

			for (int i = 0; i < Rows; i++)
			{
				this[i] = this[i].Addition(second[i]);
			}
			return this;
		}

		//j.	Вычитание матриц

		public MyMatrix Subtraction(MyMatrix second)
		{
			if (Rows != second.Rows || Columns != second.Columns)
			{
				throw new ArgumentException("размеры не совпадают");
			}

			for (int i = 0; i < Rows; i++)
			{
				this[i] = this[i].Subtraction(second[i]);
			}
			return this;
		}

		//toString | hash | equals
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			foreach (Vector vector in _rows)
			{
				sb.Append(vector).Append(Environment.NewLine);
			}
			return sb.ToString();
		}

		public override int GetHashCode()
		{
			int hash = 0;

			for (int i = 0; i < Rows; i++)
			{
				hash += this[i].GetHashCode();
			}
			return hash;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(obj, this))
			{
				return true;
			}
			if (ReferenceEquals(obj, null) || obj.GetType() != this.GetType())
			{
				return false;
			}

			var comparable = (MyMatrix)obj;

			if (Rows != comparable.Rows || Columns != comparable.Columns)
			{
				return false;
			}
			for (int i = 0; i < Rows; i++)
			{
				if (this[i].Equals(comparable[i]))
				{
					continue;
				}
				return false;
			}
			return true;
		}

		//Статические методы:
		//a.	Сложение матриц 
		public static MyMatrix Addition(MyMatrix first, MyMatrix second)
		{
			if (first.Rows != second.Rows || first.Columns != second.Columns)
			{
				throw new ArgumentException("размеры не совпадают");
			}

			return new MyMatrix(new MyMatrix(first).Addition(second));
		}
		//b.	Вычитание матриц
		public static MyMatrix Subtraction(MyMatrix first, MyMatrix second)
		{
			if (first.Rows != second.Rows || first.Columns != second.Columns)
			{
				throw new ArgumentException("размеры не совпадают");
			}

			return new MyMatrix(new MyMatrix(first).Subtraction(second));
		}
		//c.	Умножение матриц
		public static MyMatrix Multiply(MyMatrix first, MyMatrix second)
		{
			if (first.Columns != second.Rows)
			{
				throw new ArgumentException("произведение не определенно");
			}

			var result = new MyMatrix(first.Rows, second.Columns);

			for (int i = 0; i < result.Rows; i++)
			{
				for (int j = 0; j < result.Columns; j++)
				{
					result[i, j] = Vector.Composition(first[i], second.GetColumn(j));
				}
			}
			return result;
		}
	}
}