using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_Lyulyaev
{
	class Circle : IShape
	{
		private int radius;

		public double GetWidth()
		{
			return radius * 2;
		}

		public double GetHeight()
		{
			return radius * 2;
		}

		public Circle(int radius)
		{
			this.radius = radius;
		}

		public double GetPerimeter()
		{
			return 2.0 * Math.PI * radius;
		}

		public double GetArea()
		{
			return Math.PI * Math.Pow(radius, 2);
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
			Circle compared = (Circle)obj;

			return radius == compared.radius;
		}

		public override int GetHashCode()
		{
			int prime = 7;
			int hash = 1;

			hash = prime * (hash + radius);

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
