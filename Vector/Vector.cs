using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_Lyulyaev
{
	public class Vector
	{
		private double[] elements;

		public int Length => elements.Length;

		public double Module
		{
			get
			{
				double sumSquare = 0;
				foreach (double element in elements)
				{
					sumSquare += Math.Pow(element, 2); 
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

			Array.Copy(arr, elements, Math.Min(arr.Length, n));
		}

		//нестатические методы ---------------------------------------------------------

		//vec + vec
		public Vector Addition(Vector add)
		{
			if (add.Length <= Length)
			{
				for (int i = 0; i < add.Length; i++)
				{
					this[i] += add[i];
				}
				return this;
			}

			double[] result = new double[add.Length];
			Array.Copy(elements, result, Length);
			for (int i = 0; i < add.Length; i++)
			{
				result[i] += add[i];
			}
			elements = result;
			return this;
		}

		//vec - vec
		public Vector Subtraction(Vector sub)
		{
			if (sub.Length <= Length)
			{
				for (int i = 0; i < sub.Length; i++)
				{
					this[i] -= sub[i];
				}
				return this;
			}

			double[] result = new double[sub.Length];
			Array.Copy(elements, result, Length);
			for (int i = 0; i < sub.Length; i++)
			{
				result[i] -= sub[i];
			}
			elements = result;
			return this;
		}

		//vec * vec / by-component
		public Vector MultiplyByVector(Vector second)
		{
			if (Length != second.Length)
			{
				throw new ArgumentException(nameof(second));
			}

			Vector result = new Vector(this);
			for (int i = 0; i < Length; i++)
			{
				result[i] *= second[i];
			}
			return result;
		}

		//vec * num
		public Vector MultiplyByScalar(double scalar)
		{
			for (int i = 0; i < Length; i++)
			{
				elements[i] *= scalar;
			}
			return this;
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
			return new Vector(first).Addition(second);
		}

		//vec - vec
		public static Vector Subtraction(Vector first, Vector second)
		{
			return new Vector(first).Subtraction(second);
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
			int prime = 31;
			int hash = 1;

			for (int i = 0; i < Length; i++)
			{
				hash *= (int)(elements[i] % prime + hash % (i + 1));
			}

			return hash;
		}

		public override string ToString()
		{
			return new StringBuilder().Append("{\t")
									  .Append(string.Join(",\t", elements))
									  .Append("\t}").ToString();
		}
	}
}
