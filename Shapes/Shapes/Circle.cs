﻿using System;
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
	}
}
