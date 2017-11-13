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
				return new Vector(_rows[row]);
			}
			set
			{
				if (row < 0 || row >= Rows)
				{
					throw new ArgumentOutOfRangeException(nameof(row));
				}
				_rows[row] = new Vector(value);
			}
		}
		
		public double this[int row, int column]
		{
			get => _rows[row][column];
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
			if (arr.Length == 0 || arr == null)
			{
				throw new ArgumentException(nameof(arr), "недопустимый массив для копирования.");
			}

			_rows = new Vector[arr.Length / arr.GetLength(0)];
			for (int i = 0; i < _rows.Length; i++)
			{
				_rows[i] = new Vector(arr.GetLength(0));
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
			column.IsColumn = true;
			return column;
		}
		//d.	Транспонирование матрицы
		public void Transpose()
		{
			MyMatrix transposed = new MyMatrix(Columns, Rows);
			for (int i = 0; i < Rows; i++)
			{
				for (int j = 0; j < Columns; j++)
				{
					transposed[j,i] = this[i,j];
				}
			}
			_rows = transposed._rows;
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
		public MyMatrix Addition(MyMatrix second)
		{
			if (Rows != second.Rows || Columns != second.Columns)
			{
				throw new ArgumentException("размеры не совпадают");
			}

			MyMatrix result = new MyMatrix(this);

			for (int i = 0; i < Rows; i++)
			{
				result[i] = result[i].Addition(second[i]);
			}
			return result;
		}

		//j.	Вычитание матриц

		public MyMatrix Subtraction(MyMatrix second)
		{
			if (Rows != second.Rows || Columns != second.Columns)
			{
				throw new ArgumentException("размеры не совпадают");
			}

			MyMatrix result = new MyMatrix(this);

			for (int i = 0; i < Rows; i++)
			{
				result[i] = result[i].Subtraction(second[i]);
			}
			return result;
		}

		//toString | hash | equals
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			foreach (Vector vector in _rows)
			{
				sb.Append(vector.ToString()).Append(Environment.NewLine);
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

			var comparable = obj as MyMatrix;

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

			MyMatrix result = new MyMatrix(first);

			for (int i = 0; i < first.Rows; i++)
			{
				result[i] = result[i].Addition(second[i]);
			}
			return result;
		}
		//b.	Вычитание матриц
		public static MyMatrix Subtraction(MyMatrix first, MyMatrix second)
		{
			if (first.Rows != second.Rows || first.Columns != second.Columns)
			{
				throw new ArgumentException("размеры не совпадают");
			}

			MyMatrix result = new MyMatrix(first);

			for (int i = 0; i < first.Rows; i++)
			{
				result[i] = result[i].Subtraction(second[i]);
			}
			return result;
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