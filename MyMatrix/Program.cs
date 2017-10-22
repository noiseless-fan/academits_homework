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
			MyMatrix mtrx = new MyMatrix(5, 3);
			Random rand = new Random();
			for (int i = 0; i < mtrx.Rows; i++)
			{
				for (int j = 0; j < mtrx.Columns; j++)
				{
					mtrx[i, j] = rand.Next(0, 50);
				}
			}

			Console.WriteLine(mtrx);

			

			Console.WriteLine(mtrx);

			Console.ReadKey();
		}
	}
}
