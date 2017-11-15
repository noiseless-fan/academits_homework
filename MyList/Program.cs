using System;
using System.Collections.Generic;
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
			mylist.Add("werwer");
			mylist.Add("2134123");
			mylist.Add("2312");
			mylist.Add("abc");

			Console.WriteLine(mylist);
			Console.WriteLine();

			mylist.Delete(3);

			Console.WriteLine(mylist);
			Console.WriteLine();

			mylist.SetValue(3, "wertwe");

			Console.WriteLine(mylist);
			Console.WriteLine();

			Console.WriteLine(mylist.Count);

			Console.ReadKey();
		}
	}
}
