using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_Lyulyaev
{
	class Vector
	{
		private double[] elements;

		public int Length { get { return elements.Length; } }

		public double Module
		{
			get
			{
				double sumSquare = 0;

				for(int i = 0; i < elements.Length; i++)
				{
					sumSquare += Math.Pow(elements[i], 2); 
				}

				return Math.Sqrt(sumSquare);
			}
		}

		//индексатор
		[System.Runtime.CompilerServices.IndexerName("element")]
		public double this[int i]
		{
			get => elements[CheckBorders(i, Length)];
			set => elements[CheckBorders(i, Length)] = value; 
		}

		//конструкторы -------------------------------------------
		public Vector(int n)
		{
			elements = new double[CheckSize(n)];
		}

		public Vector(Vector initial)
		{
			elements = new double[initial.Length];

			Array.Copy(initial.elements, elements, Length);
		}

		public Vector(double[] arr)
		{
			elements = new double[CheckSize(arr.Length)];

			Array.Copy(arr, elements, Length);
		}

		public Vector(int n, double[] arr)
		{
			elements = new double[CheckSize(n)];

			Array.Copy(arr, elements, n < arr.Length ? n : arr.Length);
		}

		//нестатические методы ---------------------------------------------------------

		//vec + vec
		public Vector Addition(Vector add)
		{
			Vector result = new Vector(Math.Max(Length, add.Length));

			Array.Copy(elements, result.elements, result.Length < Length ? result.Length : Length);

			for (int i = 0; i < result.Length; i++)
			{
				result[i] += add[i];
			}
			return result;
		}

		//vec - vec
		public Vector Subtraction(Vector sub)
		{
			Vector result = new Vector(Math.Max(Length, sub.Length));

			Array.Copy(elements, result.elements, result.Length < Length ? result.Length : Length);

			for (int i = 0; i < result.Length; i++)
			{
				result[i] -= sub[i];
			}
			return result;
		}

		//vec * num
		public void MultiplyByScalar(double scalar)
		{
			for (int i = 0; i < Length; i++)
			{
				elements[i] *= scalar;
			}
		}

		//vec * -1
		public void Reverse()
		{
			MultiplyByScalar(-1.0);
		}

		//Статические методы ------------------------------------------------------------
		//проверка границ и размерности.
		private static int CheckSize(int number)
		{
			return number > 0 ? number : throw new ArgumentOutOfRangeException(nameof(number),"n <= 0");
		}

		private static int CheckBorders(int number, int length)
		{
			if (number >= 0 && number < length)
			{
				return number;
			}
			throw new ArgumentOutOfRangeException(nameof(number), "out of array borders");
		}

		//vec + vec
		public static Vector Addition(Vector first, Vector second)
		{
			return first.Length > second.Length ? new Vector(first).Addition(second) : new Vector(second).Addition(first);
		}

		//vec - vec
		public static Vector Subtraction(Vector first, Vector second)
		{
			return first.Length > second.Length ? new Vector(first).Subtraction(second) : new Vector(second).Subtraction(first);
		}

		//scalar (vec * vec)
		public static double Composition(Vector first, Vector second)
		{
			double result = 0;

			int iterator = Math.Min(first.Length, second.Length);
			for (int i = 0; i < iterator; i++)
			{
				result += first[i] * second[i];
			}
			return result;
		}

		// toString, HashCode, Equals --------------------------------------------------
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

			Vector comparable = obj as Vector;

			if (Length == comparable.Length)
			{
				for (int i = 0; i < Length; i++)
				{
					if (elements[i] != comparable[i])
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}

		public override int GetHashCode()
		{
			int prime = 7;
			int hash = 0;

			for (int i = 0; i < Length; i++)
			{
				hash = (int)(elements[i] % prime + hash % i);
			}

			return hash;
		}

		public override string ToString()
		{
			return new StringBuilder().Append("{ ")
									  .Append(string.Join(",", elements))
									  .Append(" }").ToString();
		}
	}
}
