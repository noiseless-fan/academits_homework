using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeClass
{
	class Program
	{
		public class RangeUsing
		{
			public static void Main()
			{
				Range first = new Range(1, 3);
				Range second = new Range(3, 6);

				Console.WriteLine("Исходные диапазоны -------------------------------");

				first.Print();
				second.Print();

				Console.WriteLine("Тестируем пересечение -------------------------------");

				Range cross = first.Cross(second);

				if (cross == null)
				{
					Console.WriteLine("диапазоны не пересекаются");
				}
				else
				{
					cross.Print();
				}

				Console.WriteLine("Тестируем сложение -------------------------------");

				Range[] addictTest = first.Addition(second);

				foreach (Range range in addictTest)
				{
					range.Print();
				}

				Console.WriteLine("Тестируем вычитание -------------------------------");

				Range[] subtractionTest = first.Subtraction(second);

				foreach (Range range in subtractionTest)
				{
					range.Print();
				}

				Console.ReadKey();
			}
		}
	}
}
