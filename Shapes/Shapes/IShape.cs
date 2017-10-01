using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_Lyulyaev
{
	interface IShape : IComparable
	{
		double GetWidth();
		double GetHeight();
		double GetArea();
		double GetPerimeter();
	}
}