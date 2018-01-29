using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArrayList
{
	class MyArrayList<T>: IList<T>
	{
		private T[] array;
		private const int defaultCapacity = 10;

		public int Count { get; private set; }

		public int Capacity
		{
			get
			{
				return array.Length;
			}
			set
			{
				IncreaseCapacity(value);
			}
		}

		public bool IsReadOnly { get; } = false;

		public MyArrayList()
		{
			array = new T[defaultCapacity];
		}

		public MyArrayList(int capacity)
		{
			array = new T[capacity];
		}

		public T this[int index]
		{
			get
			{
				CheckBounds(index);
				return array[index];
			}
			set
			{
				CheckBounds(index);
				array[index] = value;
			}
		}

		public void Add(T item)
		{
			if (Count >= array.Length)
			{
				IncreaseCapacity();
			}
			array[Count] = item;
			Count++;
		}

		public int IndexOf(T item)
		{
			for (int i = 0; i < Count; i++)
			{
				if (object.Equals(item, array[i]))
				{
					return i;
				}
			}
			return -1;
		}

		public void Insert(int index, T item)
		{
			CheckBounds(index);

			if (Count >= array.Length)
			{
				IncreaseCapacity();
			}
			if (index == Count)
			{
				Add(item);
				return;
			}
			Array.Copy(array, index, array, index + 1, Count - index);
			array[index] = item;
			Count++;
		}

		public void RemoveAt(int index)
		{
			CheckBounds(index);
			Array.Copy(array, index + 1, array, index, Count - index - 1);
			Count--;
		}

		public bool Contains(T item)
		{
			return IndexOf(item) != -1;
		}

		public void CopyTo(T[] arr, int arrIndex)
		{
			if (arrIndex + Count > arr.Length)
			{
				throw new ArgumentOutOfRangeException("массив слишком мал.");
			}
			Array.Copy(array, 0, arr, arrIndex, Count);
		}

		public bool Remove(T item)
		{
			int index = IndexOf(item);
			if (index == -1)
			{
				return false;
			}
			RemoveAt(index);
			return true;
		}

		public void TrimToSize()
		{
			if (Count < array.Length)
			{
				T[] oldItems = array;
				array = new T[Count];
				Array.Copy(oldItems, array, array.Length);
			}
		}

		public void Clear()
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = default(T);
			}
			Count = 0;
		}

		private void CheckBounds(int index)
		{
			if (index >= 0 && index < Count)
			{
				return;
			}
			throw new IndexOutOfRangeException(nameof(index));
		}

		private void IncreaseCapacity()
		{
			T[] oldItems = array;
			array = new T[oldItems.Length * 2];
			Array.Copy(oldItems, array, oldItems.Length);
		}

		private void IncreaseCapacity(int newSize)
		{
			if (newSize > array.Length)
			{
				T[] oldItems = array;
				array = new T[newSize];
				Array.Copy(oldItems, array, oldItems.Length);
			}
			else
			{
				throw new ArgumentOutOfRangeException("некорретный новый размер");
			}
		}

		//для отладки
		public override string ToString()
		{
			var sb = new StringBuilder();

			for (int i = 0; i < Count; i++)
			{
				sb.Append($" {array[i]} / ");
			}
			return sb.ToString();
		}

		public IEnumerator<T> GetEnumerator()
		{
			int initialCount = Count;
			
			foreach (T member in array)
			{
				if (initialCount != Count)
				{
					throw new ArgumentException("кол-во элементов изменилось.");
				}
				yield return member;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
