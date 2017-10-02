using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_Lyulyaev
{
	class Program
	{
		public static void Main(String[] args)
		{
			IShape circle = new Circle(5);
			IShape triangle = new Triangle(1, 3, 5, 3, 4, 7);
			IShape square = new Square(4);
			IShape rectangle = new Rectangle(2, 7);
			IShape circle2 = new Circle(4);

			IShape[] shapes = { circle, triangle, square, rectangle, circle2 };

			for (int i = 0; i < shapes.Length; i++)
			{
				Console.WriteLine("{0}", shapes[i].ToString());
			}

			Array.Sort(shapes, new ShapeAreaComparer());
			Console.WriteLine("Максимальная площадь - {0}", shapes[shapes.Length - 1].ToString());

			Array.Sort(shapes, new ShapePerimeterComparer());
			Console.WriteLine("Второй по величине периметр - {0}", shapes[shapes.Length - 2].ToString());

			Console.ReadKey();
		}
	}
}
