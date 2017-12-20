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

			mylist.Insert(4, "qweqweqwe");

			mylist.Remove("qw");

			var lines = new string[10]
			{
				"1","2","3","4","5","","","","",""
			};

			mylist.CopyTo(lines, 5);

			Console.WriteLine(mylist.Contains("qwe"));

			Console.WriteLine(mylist);
			Console.WriteLine();

			Console.ReadKey();
		}
	}
}
