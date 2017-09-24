using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_Lyulyaev
{
	class Triangle: IShape
	{
		private int X1, X2, X3, Y1, Y2, Y3;

		public double SideA { get { return Math.Sqrt(Math.Pow(X2 - X1, 2) + Math.Pow(Y2 - Y1, 2)); } }
		public double SideB { get { return Math.Sqrt(Math.Pow(X3 - X1, 2) + Math.Pow(Y3 - Y1, 2)); } }
		public double SideC { get { return Math.Sqrt(Math.Pow(X3 - X2, 2) + Math.Pow(Y3 - Y2, 2)); } }

		public Triangle(int x1, int y1, int x2, int y2, int x3, int y3)
		{
			X1 = x1;
			X2 = x2;
			X3 = x3;
			Y1 = y1;
			Y2 = y2;
			Y3 = y3;
		}

		public double GetWidth()
		{
			int[] minmax = { X1, X2, X3 };
			Array.Sort(minmax);

			return minmax[minmax.Length - 1] - minmax[0];
		}

		public double GetHeight()
		{
			int[] minmax = { Y1, Y2, Y3 };
			Array.Sort(minmax);

			return minmax[minmax.Length - 1] - minmax[0];
		}

		public double GetPerimeter()
		{
			return SideA + SideB + SideC;
		}

		public double GetArea()
		{
			double halfPerimeter = GetPerimeter() / 2;
			double area = Math.Sqrt(halfPerimeter * (halfPerimeter - SideA) * (halfPerimeter - SideB) * (halfPerimeter - SideC));

			return area;
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
			Triangle compared = (Triangle)obj;

			// TODO: мне не нравится сравнение. доделать
			
			double[] thisSides = { SideA, SideB, SideC };
			double[] comparedSides = { compared.SideA, compared.SideB, compared.SideC };

			Array.Sort(thisSides);
			Array.Sort(comparedSides);

			for (int i = 0; i < thisSides.Length; i++)
			{
				if (thisSides[i] != comparedSides[i])
				{
					return false;
				}
			}

			return true;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return base.ToString();
		}
	}
}
