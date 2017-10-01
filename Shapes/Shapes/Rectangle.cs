using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_Lyulyaev
{
	class Rectangle: IShape
	{
		private int height;
		private int width;

		public double GetHeight()
		{
			return height;
		}

		public double GetWidth()
		{
			return width;
		}

		public Rectangle(int height, int width)
		{
			this.height = height;
			this.width = width;
		}

		public double GetPerimeter()
		{
			return (width + height) * 2;
		}

		public double GetArea()
		{
			return width * height;
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
			Rectangle compared = (Rectangle)obj;

			return height == compared.height && width == compared.width;
		}

		public override int GetHashCode()
		{
			int prime = 31;
			int hash = prime * (width + width * height);

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