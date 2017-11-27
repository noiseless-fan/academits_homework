using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySLList
{
	class Program
	{
		public static void Main(String[] args)
		{
			MySLList<string> mylist = new MySLList<string>();
			mylist.Add("123");
			mylist.Add("1234");
			mylist.Add(null);
			mylist.Add("2134123");
			mylist.Add("2312");
			mylist.Add("abc");

			Console.WriteLine(mylist);
			Console.WriteLine();

			mylist.Reverse();

			Console.WriteLine(mylist);
			Console.WriteLine();

			var testCopy = mylist.Copy();

			Console.WriteLine(testCopy);

			Console.ReadKey();
		}
	}
}
