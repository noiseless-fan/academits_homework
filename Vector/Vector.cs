using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_Lyulyaev
{
	class Vector
	{
		private double[] body;

		//конструкторы -------------------------------------------
		public Vector(int n)
		{
			body = new double[CheckSize(n)];
		}

		public Vector(Vector initial)
		{
			body = new double[initial.body.Length];

			for (int i = 0; i < body.Length; i++)
			{
				body[i] = initial.body[i];
			}
		}

		public Vector(double[] arr)
		{
			body = new double[arr.Length];

			for (int i = 0; i < body.Length; i++)
			{
				body[i] = arr[i];
			}
		}

		public Vector(int n, double[] arr)
		{
			body = new double[CheckSize(n)];

			for (int i = 0; i < arr.Length && i < body.Length; i++)
			{
				body[i] = arr[i];
			}
		}

		//нестатические методы ---------------------------------------------------------

		//vec + vec
		public void Addition(Vector add)
		{
			for (int i = 0; i < Math.Min(this.body.Length, add.body.Length); i++)
			{
				this.body[i] = this.body[i] + add.body[i];
			}
		}

		//vec - vec
		public void Subtraction(Vector sub)
		{
			for (int i = 0; i < Math.Min(this.body.Length, sub.body.Length); i++)
			{
				this.body[i] = this.body[i] - sub.body[i];
			}
		}

		//vec * num
		public void MultiplyByScalar(double scalar)
		{
			for (int i = 0; i < body.Length; i++)
			{
				body[i] = body[i] * scalar;
			}
		}

		//vec * -1
		public void Reverse()
		{
			for (int i = 0; i < body.Length; i++)
			{
				body[i] = -body[i];
			}
		}

		//length
		public int GetSize()
		{
			return body.Length;
		}
		
		//get;
		public void SetValue(int idx, double value)
		{
			if (idx < 0 || idx > body.Length)
			{
				throw new ArgumentOutOfRangeException(nameof(idx), idx, "incorrect index");
			}
			body[idx] = value;
		}
		//set
		public double GetValue(int idx)
		{
			if (idx < 0 || idx > body.Length)
			{
				throw new ArgumentOutOfRangeException(nameof(idx), idx, "incorrect index");
			}
			return body[idx];
		}

		//Статические методы ------------------------------------------------------------
		private static int CheckSize(int number)
		{
			return number > 0 ? number : throw new ArgumentOutOfRangeException(nameof(number),"n <= 0");
		}

		//vec + vec
		public static Vector Addition(Vector first, Vector second)
		{
			Vector result = new Vector(Math.Max(first.body.Length, second.body.Length));

			for (int i = 0; i < Math.Min(first.body.Length, second.body.Length); i++)
			{
				result.body[i] = first.body[i] + second.body[i];
			}
			return result;
		}

		//vec - vec
		public static Vector Subtraction(Vector first, Vector second)
		{
			Vector result = new Vector(Math.Max(first.body.Length, second.body.Length));

			for (int i = 0; i < Math.Min(first.body.Length, second.body.Length); i++)
			{
				result.body[i] = first.body[i] + second.body[i];
			}
			return result;
		}

		//scalar (vec * vec)
		public static double Multiply(Vector first, Vector second)
		{
			double result = 0;

			for (int i = 0; i < Math.Min(first.body.Length, second.body.Length); i++)
			{
				result += first.body[i] * second.body[i];
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

			Vector comparable = (Vector)obj;

			if (body.Length == comparable.body.Length)
			{
				for (int i = 0; i < body.Length; i++)
				{
					if (body[i].CompareTo(comparable.body[i]) != 0)
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

			for (int i = 0; i < body.Length; i++)
			{
				hash = (int)(body[i] % prime + hash % i);
			}

			return hash;
		}

		public override string ToString()
		{
			return new StringBuilder().Append("{ ")
									  .Append(string.Join(",", body))
									  .Append(" }").ToString();
		}
	}
}
