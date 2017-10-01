using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_Lyulyaev
{
	class Square: IShape
	{
		private const int SIDES = 4;
		private int width;
		private int height;

		public double GetWidth()
		{
			return width;
		}

		public double GetHeight()
		{
			return height;
		}

		public Square(int sideSize)
		{
			width = height = sideSize;
		}

		public double GetPerimeter()
		{
			return height * SIDES;
		}

		public double GetArea()
		{
			return Math.Pow(width, 2);
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
			Square compared = (Square)obj;

			return compared.height == height;
		}

		public override int GetHashCode()
		{
			int prime = 31;
			int hash = prime * height + height;

			return hash;
		}

		public override string ToString()
		{
			return base.ToString();
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