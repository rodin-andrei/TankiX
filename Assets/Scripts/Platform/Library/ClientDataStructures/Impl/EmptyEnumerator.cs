using System;
using System.Collections;
using System.Collections.Generic;

namespace Platform.Library.ClientDataStructures.Impl
{
	public class EmptyEnumerator<T> : IEnumerator<T>, IDisposable, IEnumerator
	{
		public static IEnumerator<T> Instance = new EmptyEnumerator<T>();

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
				throw new NotSupportedException();
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
}
