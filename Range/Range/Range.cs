using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solution1
{
	public class Range
	{
		private double from;
		private double to;

		public double GetFrom()
		{
			return from;
		}

		public double GetTo()
		{
			return to;
		}

		public Range(double from, double to)
		{
			this.from = from;
			this.to = to;
		}

		public double Length()
		{
			return to - from;
		}

		public bool IsInside(double x)
		{
			return (x >= from && x <= to) ? true : false;
		}

		public void Print()
		{
			Console.WriteLine(" от {0} до {1}", from, to);
		}

		public static Range Cross(Range first, Range second)
		{
			if (!(first.IsInside(second.GetFrom()) || second.IsInside(first.GetFrom())))
			{
				return null;
			}

			double firstFrom = first.GetFrom();
			double firstTo = first.GetTo();
			double secondFrom = second.GetFrom();
			double secondTo = second.GetTo();

			double crossFrom = firstFrom >= secondFrom ? firstFrom : secondFrom;
			double crossTo = firstTo <= secondTo ? firstTo : secondTo;

			return new Range(crossFrom, crossTo);
		}
	}

	public class RangeUsing
	{
		public static void Main()
		{
			Range first = new Range(1, 3);
			Range second = new Range(-3, 0);

			first.Print();
			second.Print();

			Range cross = Range.Cross(first, second);

			if (cross == null)
			{
				Console.WriteLine("диапазоны не пересекаются");
			}
			else
			{
				cross.Print();
			}

			Console.ReadKey();
		}
	}
}
