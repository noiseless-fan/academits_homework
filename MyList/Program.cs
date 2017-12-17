using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MySLList
{
	class Program
	{
		public static void Main(String[] args)
		{
			MySLList<string> mylist = new MySLList<string>();
			mylist.Add("q");
			mylist.Add("qw");
			mylist.Add(null);
			mylist.Add("qwer");
			mylist.Add("qwert");
			mylist.Add("qwerty");

			Console.WriteLine(mylist);
			Console.WriteLine();

			mylist.DeleteByData("qw");

			Console.WriteLine(mylist);
			Console.WriteLine();

			Console.ReadKey();

			//var methods = mylist.GetType().GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public).ToList();

			//while (true)
			//{
			//	for (int i = 0; i < methods.Count; i++)
			//	{
			//		Console.WriteLine($"{i} - {methods[i].Name}");
			//	}

			//	Console.WriteLine("Select method:");

			//	int selected = Convert.ToInt32(Console.ReadLine());
			//	Console.WriteLine("выбрано - {0}", methods[selected].Name);

			//	var methodParams = methods[selected].GetParameters();
			//	var userParams = new object[methodParams.Length];

			//	for (int i = 0; i < methodParams.Length; i++)
			//	{
			//		Console.WriteLine("Enter {0} parameter - Name: {1}, Type: {2} ", i + 1, methodParams[i].Name, methodParams[i].ParameterType);
			//		userParams[i] = Convert.ChangeType(Console.ReadLine(), methodParams[i].ParameterType);
			//	}
			//	methods[selected].Invoke(mylist, userParams);

			//	Console.WriteLine();
			//	Console.WriteLine("Result:");
			//	Console.WriteLine(mylist);
			//	Console.WriteLine();

			//	Console.WriteLine("Again? y/n");
			//	char ch = Convert.ToChar(Console.ReadLine().ToLower());
			//	if (ch == 'y')
			//	{
			//		continue;
			//	}
			//	else if (ch == 'n')
			//	{
			//		break;
			//	}
			//	else
			//	{
			//		Console.WriteLine("Again? y/n");
			//	}
			//}
		}
	}
}
