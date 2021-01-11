using System;
using System.Collections;
using System.Collections.Generic;

namespace Platform.Library.ClientDataStructures.Impl
{
	public class SingletonList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		private T value;

		private IEnumerator<T> enumerator;

		public int Count
		{
			get
			{
				return 1;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return true;
			}
		}

		public T this[int index]
		{
			get
			{
				if (index == 0)
				{
					return value;
				}
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public SingletonList()
		{
		}

		public SingletonList(T value)
		{
			this.value = value;
		}

		public SingletonList<T> Init(T value)
		{
			this.value = value;
			return this;
		}

		public IEnumerator<T> GetEnumerator()
		{
			if (enumerator == null)
			{
				enumerator = new SingletonEnumerator<T>(value);
			}
			else
			{
				((SingletonEnumerator<T>)enumerator).value = value;
				enumerator.Reset();
			}
			return enumerator;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Add(T item)
		{
			throw new NotImplementedException();
		}

		public void Clear()
		{
			throw new NotImplementedException();
		}

		public bool Contains(T item)
		{
			return item.Equals(value);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			array[arrayIndex] = value;
		}

		public bool Remove(T item)
		{
			throw new NotImplementedException();
		}

		public int IndexOf(T item)
		{
			throw new NotImplementedException();
		}

		public void Insert(int index, T item)
		{
			throw new NotImplementedException();
		}

		public void RemoveAt(int index)
		{
			throw new NotImplementedException();
		}
	}
}
