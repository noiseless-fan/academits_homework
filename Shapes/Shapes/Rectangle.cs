using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_Lyulyaev
{
	class Rectangle: IShape
	{
		private int height, width;

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
	}
}
