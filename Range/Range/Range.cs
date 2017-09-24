using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_Lyulyaev
{
	public class Range
	{
		public double From { get; set; }
		public double To { get; set; }
		public double Length { get { return To - From; } }

		public Range(double from, double to)
		{
			From = from;
			To = to;
		}

		public bool IsInside(double x)
		{
			return (x >= From && x <= To);
		}

		public void Print()
		{
			Console.WriteLine(" {0}..{1} ", From, To);
		}

		public Range Cross(Range second) //don't forget a null-check then using
		{
			if (To <= second.From || second.To <= From)
			{
				return null;
			}

			double crossFrom = Math.Max(From, second.From);
			double crossTo = Math.Min(To, second.To);

			return new Range(crossFrom, crossTo);
		}

		public Range[] Addition(Range rangeTwo)
		{
			if (To < rangeTwo.From || rangeTwo.To < From)
			{
				return new Range[] { new Range(From, To), new Range(rangeTwo.From, rangeTwo.To) };
			}
			else
			{
				double newFrom = Math.Min(From, rangeTwo.From); 
				double newTo = Math.Max(To, rangeTwo.To);
				
				return new Range[] { new Range(newFrom, newTo) };
			}
		}

		public Range[] Subtraction(Range rangeTwo)
		{
			if (To < rangeTwo.From || rangeTwo.To < From)
			{
				return new Range[] { new Range(From, To), new Range(rangeTwo.From, rangeTwo.To) };
			}
			else
			{
				if (From == rangeTwo.From)
				{
					if (To <= rangeTwo.To)
					{
						return null;
					}
					return new Range[] { new Range(rangeTwo.To, To) };
				}
				else if (From > rangeTwo.From)
				{
					if (rangeTwo.To >= To)
					{
						return null;
					}
					return new Range[] { new Range(rangeTwo.To, To) };
				}
				else
				{
					if (To <= rangeTwo.To)
					{
						return new Range[] { new Range(From, rangeTwo.From) };
					}
					return new Range[] { new Range(From, rangeTwo.From), new Range(rangeTwo.To, To) };
				}
			}
		}
	}
}