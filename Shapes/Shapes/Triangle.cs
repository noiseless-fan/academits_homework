using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_Lyulyaev
{
	class Triangle: IShape
	{
		private int x1,
					x2,
					x3,
					y1,
					y2,
					y3;

		public double sideA { get { return SideCompute(x1, y1, x2, y2); } }
		public double sideB { get { return SideCompute(x1, y1, x3, y3); } }
		public double sideC { get { return SideCompute(x2, y2, x3, y3); } }

		public Triangle(int x1, int y1, int x2, int y2, int x3, int y3)
		{
			this.x1 = x1;
			this.x2 = x2;
			this.x3 = x3;
			this.y1 = y1;
			this.y2 = y2;
			this.y3 = y3;
		}

		public double GetWidth()
		{
			int[] minmax = { x1, x2, x3 };
			Array.Sort(minmax);

			return minmax[minmax.Length - 1] - minmax[0];
		}

		public double GetHeight()
		{
			int[] minmax = { y1, y2, y3 };
			Array.Sort(minmax);

			return minmax[minmax.Length - 1] - minmax[0];
		}

		public double GetPerimeter()
		{
			return sideA + sideB + sideC;
		}

		public double GetArea()
		{
			double halfPerimeter = GetPerimeter() / 2;
			double area = Math.Sqrt(halfPerimeter * (halfPerimeter - sideA) * (halfPerimeter - sideB) * (halfPerimeter - sideC));

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

			return	(x1 == compared.x1 && y1 == compared.y1) 
					&& (x2 == compared.x2 && y2 == compared.y2) 
					&& (x3 == compared.x3 && y3 == compared.y3);
		}

		public override int GetHashCode()
		{
			int prime = 7;
			int hash = 1;

			int[] coords = { x1, y1, x2, y2, x3, y3 };

			for (int i = 0; i < coords.Length; i++)
			{
				hash = hash * coords[i] + prime;
			}

			return hash;
		}

		public override string ToString()
		{
			return base.ToString();
		}

		private static double SideCompute(double x1, double y1, double x2, double y2)
		{
			return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
		}

		public int CompareTo(object obj)
		{
			if (obj.GetType() is IShape)
			{
				return -1;
			}

			IShape shape = (IShape)obj;

			if (this == null && shape != null)
			{
				return -1;
			}
			if (shape == null && this != null)
			{
				return 1;
			}
			if (this == null && shape == null)
			{
				return 0;
			}

			int thisArea = (int)this.GetArea();
			int shapeArea = (int)shape.GetArea();

			if (thisArea > shapeArea)
			{
				return 1;
			}
			else if (thisArea == shapeArea)
			{
				return 0;
			}
			return -1;
		}
	}
}
