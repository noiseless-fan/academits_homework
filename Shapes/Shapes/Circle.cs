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

		public Circle(int radius)
		{
			this.radius = radius;
		}

		public double GetWidth()
		{
			return radius * 2;
		}

		public double GetHeight()
		{
			return radius * 2;
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
			return $"{GetType().Name}, with radius {radius}";
		}
	}
}