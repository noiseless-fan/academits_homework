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

			IShape[] shapes = { circle, triangle, square, rectangle, circle2 };

			Array.Sort<IShape>(shapes);

			for (int i = 0; i < shapes.Length; i++)
			{
				Console.WriteLine("Area {0}, perimeter {1}", shapes[i].GetArea(), shapes[i].GetPerimeter());

			}

			Console.WriteLine("Максимальная площадь - {0}, {1}", shapes[shapes.Length - 1].ToString(), shapes[shapes.Length - 1].GetArea());
			Console.WriteLine("Второй по величине периметр - {0}, {1}", shapes[shapes.Length - 2].ToString(), shapes[shapes.Length - 2].GetPerimeter());

			//MaxArea(circle, circle2, triangle, square, rectangle);
			//SecondPerimeter(circle, circle2, triangle, square, rectangle);

			Console.ReadKey();
		}
	}
}
