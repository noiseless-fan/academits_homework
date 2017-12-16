using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySLList
{ 
	public class MySLList<T>: IEnumerable<T>
	{
		//•	получение первого узла -------------
		public Node<T> First { get; private set; }
		//•	получение размера списка -----------
		public int Count { get; private set; }

		public MySLList()
		{
		}

		//•	получение узла по индексу ---------------------
		//Изменение значения по индексу пусть выдает старое значение. ---------
		//•	получение/изменение значения по указанному индексу. --------------

		public T GetValue(int index)
		{
			return GetNodeByIndex(index).Data;
		}

		public T SetValue(int index, T data)
		{
			var temp = GetNodeByIndex(index);
			var tempData = temp.Data;
			temp.Data = data;
			return tempData;
		}

		public void Add(T data)
		{
			Node<T> newItem = new Node<T>(data);
			if (First == null)
			{
				First = newItem;
			}
			else
			{
				GetNodeByIndex(Count - 1).Next = newItem;
			}
			Count++;
		}

		//•	вставка элемента в начало ---------------------
		public void AddFirst(T data)
		{
			if (Count == 0)
			{
				Add(data);
				return;
			}
			Node<T> temp = First;
			First = new Node<T>(data, temp);
			Count++;
		}
		//•	удаление первого элемента, пусть выдает значение элемента ---------------
		public T DeleteFirst()
		{
			if (Count == 0)
			{
				throw new ArgumentException("nothing to delete");
			}

			T tempData = First.Data;
			First = First.Next;
			Count--;
			return tempData;
		}

		//•	удаление элемента по индексу, пусть выдает значение элемента -------------
		public T DeleteByIndex(int index)
		{
			CheckBounds(index);

			if (Count == 0)
			{
				throw new ArgumentException("nothing to delete");
			}

			if (index == 0)
			{
				return DeleteFirst();
			}

			Node<T> prev = GetNodeByIndex(index - 1);
			T tempData = prev.Next.Data;
			prev.Next = prev.Next.Next;
			Count--;
			return tempData;
		}

		//•	удаление узла по значению -------------------
		public bool DeleteByData(T data)
		{
			if (Count == 0)
			{
				return false;
			}
			if ((First.Data == null && data == null) || First.Data.Equals(data))
			{
				DeleteFirst();
				return true;
			}

			for (Node<T> temp = First.Next, prev = First; temp != null; prev = temp, temp = temp.Next)
			{
				if ((temp.Data == null && data == null) || temp.Data.Equals(data))
				{
					prev.Next = temp.Next;
					Count--;
					return true;
				}
			}
			return false;
		}

		//•	вставка элемента по индексу -------------------
		public void Insert(int index, T data)
		{
			Node<T> prev = GetNodeByIndex(index - 1);
			prev.Next = new Node<T>(data, prev.Next);
			Count++;
		}

		//	вставка и удаление узла после указанного узла
		public void DeleteAfter(Node<T> paste)
		{
			if (Count <= 1)
			{
				return;
			}
			
			foreach (Node<T> node in GetNodes())
			{
				if ((node.Data == null && paste.Data == null) || node.Data.Equals(paste.Data))
				{
					if (node.Next != null)
					{
						node.Next = node.Next.Next;
					}
				}
			}
		}

		//•	разворот списка за линейное время
		public void Reverse()
		{
			if (Count <= 1)
			{
				return;
			}
			if (Count == 2)
			{
				Node<T> temp = First;
				First = temp.Next;
				First.Next = temp;
				temp.Next = null;
				return;
			}

			Node<T> next = First.Next.Next;
			Node<T> current = First.Next;
			Node<T> prev = First;
			prev.Next = null;

			for (; next != null; prev = current, current = next, next = next.Next)
			{
				current.Next = prev;
				if (next.Next == null)
				{
					next.Next = current;
					First = next;
					break;
				}
			}
		}

		//копирование списка
		public MySLList<T> Copy()
		{
			if (Count == 0)
			{
				return new MySLList<T>();
			}

			MySLList<T> copy = new MySLList<T>
			{
				First = new Node<T>(this.First.Data)
			};

			for (Node<T> copyTo = copy.First, copyFrom = this.First.Next; 
				copyFrom != null; 
				copyFrom = copyFrom.Next, copyTo = copyTo.Next)
			{
				copyTo.Next = new Node<T>(copyFrom.Data);
			}
			return copy;
		}

		public void Reset()
		{
			First = null;
			Count = 0;
		}

		//2* (Эта задача не обязательная). Есть односвязный список, каждый элемент которого хранит дополнительную ссылку 
		//на произвольный элемент списка.Эта ссылка может быть и null.
		//Надо создать копию этого списка, чтобы в копии эти произвольные ссылки ссылались на соответствующие элементы в копии.
		public override string ToString()
		{
			var sb = new StringBuilder();
			foreach (T data in this)
			{
				sb.Append(data + Environment.NewLine);
			}
			return sb.ToString();
		}

		//приватные методы
		private Node<T> GetNodeByIndex(int index)
		{
			CheckBounds(index);

			int iterator = index;
			for (Node<T> node = First; node != null; node = node.Next, iterator--)
			{
				if (iterator == 0)
				{
					return node;
				}
			}
			return null;
		}

		private void CheckBounds(int index)
		{
			if (index < 0 || index > Count)
			{
				throw new ArgumentOutOfRangeException(nameof(index));
			}
		}

		private IEnumerable<Node<T>> GetNodes()
		{
			for (Node<T> temp = First; temp != null; temp = temp.Next)
			{
				yield return temp;
			}
		} 

		IEnumerator IEnumerable.GetEnumerator()
		{
			return (IEnumerator<T>)GetEnumerator();
		}

		public IEnumerator<T> GetEnumerator()
		{
			for (Node<T> temp = First; temp != null; temp = temp.Next)
			{
				yield return temp.Data;
			}
		}
	}
}
