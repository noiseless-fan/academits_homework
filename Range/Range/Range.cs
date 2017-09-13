using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeClass
{
	public class Range
	{
		public double From { get; set; }
		public double To { get; set; }

		public Range(double from, double to)
		{
			From = from;
			To = to;
		}

		public double Length()
		{
			return To - From;
		}

		public bool IsInside(double x)
		{
			return (x >= From && x <= To);
		}

		public void Print()
		{
			Console.WriteLine(" от {0} до {1}", From, To);
		}

		public Range Cross(Range second) //don't forget a null-check then using
		{
			if (this.To <= second.From || second.To <= this.From)
			{
				return null;
			}

			double crossFrom = this.From > second.From ? this.From : second.From;
			double crossTo = this.To < second.To ? this.To : second.To;

			return new Range(crossFrom, crossTo);
		}

		public static Range[] Addition(Range rng_fst, Range rng_sec)
		{
			if (rng_fst.To < rng_sec.From || rng_sec.To < rng_fst.From)
			{
				return new Range[] { rng_fst, rng_sec };
			}
			else
			{
				double newFrom = rng_fst.From <= rng_sec.From ? rng_fst.From : rng_sec.From;
				double newTo = rng_fst.To >= rng_sec.To ? rng_fst.To : rng_sec.To;

				return new Range[] { new Range(newFrom, newTo) };
			}
		}
	}
}
