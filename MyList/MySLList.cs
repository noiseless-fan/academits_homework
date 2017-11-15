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
		public T Data { get; set; }
		public Node<T> Next { get; set; } = null;

		public Node(T data)
		{
			Data = data;
		}
		public Node(T data, Node<T> next)
		{
			Data = data;
			Next = next;
		}
	}

	public class MySLList<T>: IEnumerable
	{
		//•	получение первого узла -------------
		public Node<T> First { get; set; } = null;
		//•	получение размера списка -----------
		public int Count { get; private set; } = 0;

		//•	получение/изменение значения по указанному индексу. --------------
		public Node<T> this[int index]
		{
			//•	получение узла по индексу ---------------------
			get
			{
				int iterator = CheckBounds(index, Count);
				Node<T> temp = First;
				for (; temp != null && iterator != 1; temp = temp.Next, iterator--)
				{ }
				return temp;
			}
			set
			{
				int iterator = CheckBounds(index, Count);
				Node<T> temp = First;
				for (; temp != null && iterator != 1; temp = temp.Next, iterator--)
				{ }
				Console.WriteLine("old value = {0}", temp.Data);
				temp.Data = value.Data;
				Console.WriteLine("new value = {0}", temp.Data);
			}
		}

		public MySLList()
		{
		}

		public T GetValue(int index)
		{
			int iterator = CheckBounds(index, Count);
			return this[index].Data;
		}

		//Изменение значения по индексу пусть выдает старое значение. ---------
		public void SetValue(int index, T data)
		{
			int iterator = CheckBounds(index, Count);
			foreach (Node<T> node in this)
			{
				if (iterator == 1)
				{
					Console.WriteLine("old value = {0}", node.Data);
					Console.WriteLine("new value = {0}", data);
					node.Data = data;
					return;
				}
				iterator--;
			}
		}

		public void Add(T data)
		{
			Node<T> newItem = new Node<T>(data);
			if (First == null)
			{
				First = newItem;
			}
			else if (First.Next == null)
			{
				First.Next = newItem;
			}
			else
			{
				this[Count].Next = newItem;
			}
			Count++;
		}

		//•	вставка элемента в начало ---------------------
		public void AddToTop(T data)
		{
			Node<T> temp = First;
			First = new Node<T>(data, temp);
			Count++;
		}

		//•	удаление первого элемента, пусть выдает значение элемента ---------------
		public void DeleteFromTop()
		{
			Console.WriteLine("deleted value = {0}", First.Data);
			First = First.Next;
			Count--;
		}

		//•	удаление элемента по индексу, пусть выдает значение элемента -------------
		public void Delete(int index)
		{
			index = CheckBounds(index, Count);

			if (Count > 0)
			{
				Node<T> temp = First;
				Node<T> prev = null;
				int iterator = index;
				for (; temp.Next != null ; prev = temp, temp = temp.Next, iterator--)
				{
					if (iterator == 1)
					{
						Console.WriteLine("deleted value = {0}", prev.Next.Data);
						prev.Next = temp.Next;
						prev = null;
						Count--;
					}
				}	
			}
			else
			{
				Console.WriteLine("nothing to delete");
			}
		}

		//•	удаление узла по значению -------------------
		public void Delete(T data)
		{
			Node<T> temp = First;
			Node<T> prev = null;

			for (; temp.Next != null; prev = temp, temp = temp.Next)
			{
				if (temp.Data.Equals(data))
				{
					prev.Next = temp.Next;
					temp = null;
					Count--;
					break;
				}
			}
 		}

		//•	вставка элемента по индексу -------------------
		public void Insert(int index, T data)
		{
			index = CheckBounds(index, Count);

			Node<T> temp = this[index];
			this[index - 1].Next = new Node<T>(data, temp);
			Count++;
		}

		private static int CheckBounds(int index, int count)
		{
			return (index <= 0 || index > count) ? throw new ArgumentOutOfRangeException(nameof(index)) : index;
		}

		public void Reverse()
		{

		}
		
		//TODO:•	вставка и удаление узла после указанного узла ???? Указанного по индексу или значению?
		//•	разворот списка за линейное время
		//•	копирование списка
		//2* (Эта задача не обязательная). Есть односвязный список, каждый элемент которого хранит дополнительную ссылку 
		//на произвольный элемент списка.Эта ссылка может быть и null.
		//Надо создать копию этого списка, чтобы в копии эти произвольные ссылки ссылались на соответствующие элементы в копии.
		public override string ToString()
		{
			var sb = new StringBuilder();
			foreach (Node<T> var in this)
			{
				sb.Append(var.Data + Environment.NewLine);
			}
			return sb.ToString();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			Node<T> temp = First;
			while (temp != null)
			{
				yield return temp;
				temp = temp.Next;
			}
			yield break;
		}
	}
}
