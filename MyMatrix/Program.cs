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
			MyMatrix mtrx = new MyMatrix(new double[4][] 
			{
				new double[] { 2,5,1,-4},
				new double[] { 0,-2,1,6},
				new double[] { 3,-7,0,5},
				new double[] { 1,-1,0,3}
			});

			/* 
			Random rand = new Random();
			for (int i = 0; i < mtrx.Rows; i++)
			{
				for (int j = 0; j < mtrx.Columns; j++)
				{
					mtrx[i, j] = rand.Next(0, 50);
				}
			}
			*/

			Console.WriteLine(mtrx);

			Console.WriteLine(mtrx.Determinant());

			Console.ReadKey();
		}
	}
}
