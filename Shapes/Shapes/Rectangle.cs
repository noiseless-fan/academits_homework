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

		public Rectangle(int height, int width)
		{
			this.height = height;
			this.width = width;
		}

		public double GetHeight()
		{
			return height;
		}

		public double GetWidth()
		{
			return width;
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
			return $"{nameof(Rectangle)}, with width {width} and height {height}.";
		}
	}
}