using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySLList
{
	public class Node<T>
	{
		private T data;

		public T Data
		{
			get => data;
			set
			{
				OnChange(value);
				data = value;	
			}
		}

		public Node<T> Next { get; set; }

		public Node(T data)
		{
			this.data = data;
		}
		public Node(T data, Node<T> next)
		{
			this.data = data;
			Next = next;
		}

		private void OnChange(T value)
		{
			Console.WriteLine("old value => {0}", data);
			Console.WriteLine("new value => {0}", value);
		}
	}
}