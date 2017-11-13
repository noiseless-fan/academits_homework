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
			MyMatrix mtrx = new MyMatrix(new double[,] 
			{
				{ 2,5,1,-4},
				{ 0,-2,1,6},
				{ 3,-7,0,5},
				{ 1,-1,0,3}
			});

			Console.WriteLine(mtrx);
			Console.WriteLine(mtrx.Determinant());
			Console.WriteLine();

			MyMatrix mtrx1 = new MyMatrix(3, 2);
			mtrx1.FillRandom();

			MyMatrix mtrx2 = new MyMatrix(3, 2);
			mtrx2.FillRandom();

			Console.WriteLine(mtrx1);
			Console.WriteLine(mtrx2);

			Console.WriteLine($"{mtrx1.GetHashCode()}, {mtrx2.GetHashCode()}");
			Console.WriteLine(mtrx1.Equals(mtrx2));

			Console.ReadKey();
		}
	}
}
