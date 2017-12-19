using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MyArrayList
{
	class Program
	{
		public static void Main(String[] args)
		{
			var mylist = new MyArrayList<string>
			{
				"q",
				"qw",
				"qwe",
				"qwer",
				"qwert"
			};

			Console.WriteLine(mylist);
			Console.WriteLine();

			mylist[3] = "qweqwe";

			mylist.TrimToSize();

			mylist.Insert(3, "qweqweqwe");

			mylist.Remove("qw");

			Console.WriteLine(mylist.Contains("qwe"));

			Console.WriteLine(mylist);
			Console.WriteLine();

			Console.ReadKey();
		}
	}
}
