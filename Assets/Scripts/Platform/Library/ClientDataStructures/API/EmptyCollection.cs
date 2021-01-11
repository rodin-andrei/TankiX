using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Platform.Library.ClientDataStructures.API
{
	public class EmptyCollection<T> : ICollection<T>, ICollection, IEnumerable<T>, IEnumerable
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct EmptyEnumerator : IEnumerator<T>, IDisposable, IEnumerator
		{
			object IEnumerator.Current
			{
				get
				{
					throw new NotImplementedException();
				}
			}

			public T Current
			{
				get
				{
					throw new NotImplementedException();
				}
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				return false;
			}

			public void Reset()
			{
			}
		}

		public object SyncRoot
		{
			get
			{
				return this;
			}
		}

		public bool IsSynchronized
		{
			get
			{
				return true;
			}
		}

		public int Count
		{
			get
			{
				return 0;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return true;
			}
		}

		public void CopyTo(Array array, int index)
		{
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
			return false;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
		}

		public bool Remove(T item)
		{
			throw new NotImplementedException();
		}

		public IEnumerator<T> GetEnumerator()
		{
			return default(EmptyEnumerator);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return default(EmptyEnumerator);
		}
	}
}
