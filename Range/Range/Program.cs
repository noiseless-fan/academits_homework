using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_Lyulyaev
{
	public class Program
	{
		public class RangeUsing
		{
			public static void Main()
			{
				Range first = new Range(1, 2);
				Range second = new Range(1, 2);

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

				Range[] test = { new Range(1, 2), new Range(1, 3), new Range(3, 4), new Range(1, 4) };

				for (int i = 1; i < test.Length; i++)
				{
					Console.Write(" {0} - {1} = ", test[i].ToString(), test[i - 1].ToString());

					Range[] subsTest = test[i].Subtraction(test[i - 1]);
					if (subsTest.Length == 0)
					{
						Console.WriteLine("Пустой массив.");
					}
					foreach (Range range in subsTest)
					{
						range.Print();
					}

					Console.Write(" {0} - {1} = ", test[i - 1].ToString(), test[i].ToString());

					subsTest = test[i - 1].Subtraction(test[i]);
					if (subsTest.Length == 0)
					{
						Console.WriteLine("Пустой массив.");
					}
					foreach (Range range in subsTest)
					{
						range.Print();
					}
				}
				Console.ReadKey();
			}
		}
	}
}
