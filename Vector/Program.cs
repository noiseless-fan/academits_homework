using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_Lyulyaev
{
	public class Program
	{
		public static void Main(String[] args)
		{
			double[] arr1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			double[] arr2 = { 5, 6, 7, 8, 9, 10, 11, 12, 13 };

			Vector vector1 = new Vector(5);
			Vector vector2 = new Vector(arr1);
			Vector vector3 = new Vector(arr2);
			Vector vector4 = new Vector(vector3).Addition(vector2);

			Console.Write($"{vector1},");
			vector1.Addition(vector2);
			Console.WriteLine($"{vector1}");

			Console.Write($"{vector2},");
			vector2.Addition(vector3);
			Console.WriteLine($"{vector2}");

			Console.Write($"{vector3},");
			vector3.Subtraction(vector2);
			Console.WriteLine($"{vector3}");

			Console.WriteLine($"{vector2}, {vector2.Module}");
			Console.Write($"{vector4}, ");
			vector4.Reverse();
			Console.WriteLine($"{vector4}");

			Console.WriteLine($"{vector2}, {vector2.Equals(vector2)}");

			Console.WriteLine($"{vector3}, {Vector.Composition(vector2,vector3)}");

			Console.ReadKey();
		}
	}
}
