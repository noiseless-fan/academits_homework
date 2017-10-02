using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_Lyulyaev
{
	public class ShapePerimeterComparer: IComparer<IShape>
	{
		public int Compare(IShape sh1, IShape sh2)
		{
			if (sh1 == null && sh2 != null)
			{
				return -1;
			}
			if (sh2 == null && sh1 != null)
			{
				return 1;
			}
			if (sh1 == null && sh2 == null)
			{
				return 0;
			}

			return (int)(sh1.GetPerimeter() - sh2.GetPerimeter());
		}
	}
}