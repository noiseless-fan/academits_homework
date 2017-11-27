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
		public Node<T> First { get; set; }
		//•	получение размера списка -----------
		public int Count { get; private set; }

		public Node<T> this[int index]
		{
			get
			{
				CheckBounds(index);
				int iterator = index;
				Node<T> temp = First;
				for (; temp != null && iterator != 1; temp = temp.Next, iterator--)
				{ }
				return temp;
			}
		}

		public MySLList()
		{
		}

		//•	получение узла по индексу ---------------------
		//Изменение значения по индексу пусть выдает старое значение. ---------
		//•	получение/изменение значения по указанному индексу. --------------

		public T GetValue(int index)
		{
			CheckBounds(index);
			return this[index].Data;
		}

		public T SetValue(int index, T data)
		{
			CheckBounds(index);
			T temp = this[index].Data;
			this[index].Data = data;
			return temp;
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
		public T DeleteFromTop()
		{
			T temp = First.Data;
			First = First.Next;
			Count--;
			return temp;
		}

		//•	удаление элемента по индексу, пусть выдает значение элемента -------------
		public T Delete(int index)
		{
			CheckBounds(index);

			if (Count > 0)
			{
				Node<T> temp = First;
				Node<T> prev = null;
		
				int iterator = index;
				for (; temp.Next != null ; prev = temp, temp = temp.Next, iterator--)
				{
					if (iterator == 1)
					{
						T tempdata = prev.Next.Data;
						prev.Next = temp.Next;
						prev = null;
						Count--;
						return tempdata;
					}
				}	
			}
			else
			{
				throw new ArgumentException();
			}
			return default(T);
		}

		//•	удаление узла по значению -------------------
		public bool Delete(T data)
		{
			Node<T> temp = First;
			Node<T> prev = null;

			bool isDeleted = false;

			for (; temp.Next != null; prev = temp, temp = temp.Next)
			{
				if (temp.Data.Equals(data))
				{
					prev.Next = temp.Next;
					isDeleted = true;
					Count--;
					break;
				}
			}
			return isDeleted;
 		}

		//•	вставка элемента по индексу -------------------
		public void Insert(int index, T data)
		{
			CheckBounds(index);

			Node<T> temp = this[index];
			this[index - 1].Next = new Node<T>(data, temp);
			Count++;
		}

		//	вставка и удаление узла после указанного узла
		public void DeleteAfter(Node<T> paste)
		{
			Delete(paste.Data);
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

		//•	копирование списка
		public MySLList<T> Copy()
		{
			MySLList<T> copy = new MySLList<T>
			{
				First = new Node<T>(this.First.Data)
			};

			for (Node<T> copyTo = copy.First, copyFrom = this.First.Next; copyFrom != null; copyFrom = copyFrom.Next, copyTo = copyTo.Next)
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

		private void CheckBounds(int index)
		{
			if (index <= 0 || index > Count)
			{
				throw new ArgumentOutOfRangeException(nameof(index));
			}
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
