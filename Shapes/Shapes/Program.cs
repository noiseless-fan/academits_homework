using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_Lyulyaev
{
	class Program
	{
		public static void MaxArea(params IShape[] shapes)
		{
			int maxIndex = 0;
			for (int i = 0; i < shapes.Length; i++)
			{
				maxIndex = shapes[i].GetArea() > shapes[maxIndex].GetArea() ? i : maxIndex;
			}
			Console.WriteLine(shapes[maxIndex]);
		}

		public static void SecondPerimeter(params IShape[] shapes)
		{
			
		}

		public static void Main(String[] args)
		{
			IShape circle = new Circle(5);
			IShape triangle = new Triangle(1, 3, 5, 3, 4, 7);
			IShape square = new Square(4);
			IShape rectangle = new Rectangle(2, 7);
			IShape circle2 = new Circle(4);

			MaxArea(circle, circle2, triangle, square, rectangle);
			SecondPerimeter(circle, circle2, triangle, square, rectangle);

			Console.ReadKey();
		}
	}
}
