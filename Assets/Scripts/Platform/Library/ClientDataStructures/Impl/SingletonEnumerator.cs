using System;
using System.Collections;
using System.Collections.Generic;

namespace Platform.Library.ClientDataStructures.Impl
{
	internal class SingletonEnumerator<T> : IEnumerator<T>, IDisposable, IEnumerator
	{
		internal T value;

		private bool first;

		object IEnumerator.Current
		{
			get
			{
				return Current;
			}
		}

		public T Current
		{
			get
			{
				return value;
			}
		}

		public SingletonEnumerator(T value)
		{
			this.value = value;
			first = true;
		}

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			if (first)
			{
				first = false;
				return true;
			}
			return false;
		}

		public void Reset()
		{
			first = true;
		}
	}
}
