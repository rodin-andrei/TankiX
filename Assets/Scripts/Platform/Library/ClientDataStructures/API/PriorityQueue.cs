using System;
using System.Collections;
using System.Collections.Generic;
using Platform.Library.ClientDataStructures.Impl;

namespace Platform.Library.ClientDataStructures.API
{
	public class PriorityQueue<T> : IPriorityQueue<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		private struct Enumerator : IEnumerator<T>, IDisposable, IEnumerator
		{
			private PriorityQueue<T> pq;

			private int index;

			private int ver;

			private EnumeratorHelper.EnumeratorState state;

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
					EnumeratorHelper.CheckCurrentState(state);
					return pq.items[index];
				}
			}

			internal Enumerator(PriorityQueue<T> pq)
			{
				this.pq = pq;
				ver = pq.version;
				index = -1;
				state = EnumeratorHelper.EnumeratorState.Before;
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				EnumeratorHelper.CheckVersion(ver, pq.version);
				switch (state)
				{
				case EnumeratorHelper.EnumeratorState.Before:
					if (pq.Count == 0)
					{
						state = EnumeratorHelper.EnumeratorState.After;
						return false;
					}
					state = EnumeratorHelper.EnumeratorState.Current;
					index = 1;
					return true;
				case EnumeratorHelper.EnumeratorState.After:
					return false;
				default:
					if (++index > pq.Count)
					{
						state = EnumeratorHelper.EnumeratorState.After;
						return false;
					}
					return true;
				}
			}

			void IEnumerator.Reset()
			{
				EnumeratorHelper.CheckVersion(ver, pq.version);
				state = EnumeratorHelper.EnumeratorState.Before;
			}
		}

		private IComparer<T> comparer;

		private List<T> items;

		private int version;

		public int Count
		{
			get
			{
				return items.Count - 1;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		public PriorityQueue(IComparer<T> comparer)
		{
			this.comparer = comparer;
			Init();
		}

		public PriorityQueue(Comparison<T> comparison)
			: this(Comparers.GetComparer(comparison))
		{
		}

		public PriorityQueue()
			: this(Comparers.GetComparer<T>())
		{
		}

		private void Init()
		{
			items = new List<T>();
			items.Add(default(T));
		}

		public void Add(T item)
		{
			Enqueue(item);
		}

		public void Clear()
		{
			Init();
			version++;
		}

		public bool Contains(T item)
		{
			return items.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			for (int i = 1; i < items.Count; i++)
			{
				array[arrayIndex + i - 1] = items[i];
			}
		}

		public bool Remove(T item)
		{
			throw new NotImplementedException();
		}

		public T Peek()
		{
			if (Count == 0)
			{
				throw new QueueIsEmptyException();
			}
			return items[1];
		}

		public T Dequeue()
		{
			if (Count == 0)
			{
				throw new QueueIsEmptyException();
			}
			T result = items[1];
			items[1] = items[items.Count - 1];
			items.RemoveAt(items.Count - 1);
			BubbleDown(1);
			version++;
			return result;
		}

		public void Enqueue(T item)
		{
			items.Add(item);
			BubbleUp(items.Count - 1);
			version++;
		}

		private void BubbleDown(int i)
		{
			int num = i * 2;
			int num2 = i * 2 + 1;
			int num3 = i;
			if (num < items.Count && comparer.Compare(items[num], items[i]) < 0)
			{
				num3 = num;
			}
			if (num2 < items.Count && comparer.Compare(items[num2], items[num3]) < 0)
			{
				num3 = num2;
			}
			if (num3 != i)
			{
				T value = items[num3];
				items[num3] = items[i];
				items[i] = value;
				BubbleDown(num3);
			}
		}

		private void BubbleUp(int i)
		{
			int num = i;
			int num2 = i / 2;
			while (num2 != 0 && comparer.Compare(items[num2], items[num]) > 0)
			{
				T value = items[num2];
				items[num2] = items[num];
				items[num] = value;
				num = num2;
				num2 = num / 2;
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			return new Enumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
