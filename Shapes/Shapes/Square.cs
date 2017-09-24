using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_Lyulyaev
{
	class Square: IShape
	{
		private const int Sides = 4;
		private int Width;
		private int Height;

		public double GetWidth()
		{
			return Width;
		}

		public double GetHeight()
		{
			return Height;
		}

		public Square(int sideSize)
		{
			Width = Height = sideSize;
		}

		public double GetPerimeter()
		{
			return Height * Sides;
		}

		public double GetArea()
		{
			return Math.Pow(Width, 2);
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

			return compared.Height == Height;
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
