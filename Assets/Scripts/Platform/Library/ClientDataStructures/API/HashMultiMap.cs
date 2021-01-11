using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Platform.Library.ClientDataStructures.API
{
	public class HashMultiMap<TKey, TValue> : IMultiMap<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
	{
		private struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IDisposable, IEnumerator
		{
			private HashMultiMap<TKey, TValue> multimap;

			private IEnumerator<TKey> keyEnumerator;

			private IEnumerator<TValue> valueEnumerator;

			private int ver;

			private EnumeratorHelper.EnumeratorState state;

			object IEnumerator.Current
			{
				get
				{
					return Current;
				}
			}

			public KeyValuePair<TKey, TValue> Current
			{
				get
				{
					EnumeratorHelper.CheckCurrentState(state);
					return new KeyValuePair<TKey, TValue>(keyEnumerator.Current, valueEnumerator.Current);
				}
			}

			public Enumerator(HashMultiMap<TKey, TValue> multimap)
			{
				this.multimap = multimap;
				ver = multimap.version;
				state = EnumeratorHelper.EnumeratorState.Before;
				keyEnumerator = null;
				valueEnumerator = null;
			}

			public bool MoveNext()
			{
				EnumeratorHelper.CheckVersion(ver, multimap.version);
				switch (state)
				{
				case EnumeratorHelper.EnumeratorState.Before:
				{
					keyEnumerator = multimap.data.Keys.GetEnumerator();
					bool flag = keyEnumerator.MoveNext();
					if (flag)
					{
						valueEnumerator = multimap.data[keyEnumerator.Current].GetEnumerator();
						valueEnumerator.MoveNext();
						state = EnumeratorHelper.EnumeratorState.Current;
					}
					else
					{
						state = EnumeratorHelper.EnumeratorState.After;
					}
					return flag;
				}
				case EnumeratorHelper.EnumeratorState.After:
					return false;
				default:
				{
					bool flag = valueEnumerator.MoveNext();
					if (!flag)
					{
						flag = keyEnumerator.MoveNext();
						if (flag)
						{
							valueEnumerator = multimap.data[keyEnumerator.Current].GetEnumerator();
							valueEnumerator.MoveNext();
						}
					}
					if (!flag)
					{
						state = EnumeratorHelper.EnumeratorState.After;
					}
					return flag;
				}
				}
			}

			public void Reset()
			{
				state = EnumeratorHelper.EnumeratorState.Before;
			}

			public void Dispose()
			{
			}
		}

		private int count;

		private int version;

		private Dictionary<TKey, ICollection<TValue>> data = new Dictionary<TKey, ICollection<TValue>>();

		public int Count
		{
			get
			{
				return count;
			}
		}

		public ICollection<TValue> this[TKey key]
		{
			get
			{
				ICollection<TValue> value;
				return (!data.TryGetValue(key, out value)) ? Collections.EmptyList<TValue>() : value;
			}
			set
			{
				data[key] = value;
			}
		}

		public ICollection<TKey> Keys
		{
			get
			{
				return data.Keys;
			}
		}

		public ICollection<TValue> Values
		{
			get
			{
				List<TValue> list = new List<TValue>();
				foreach (ICollection<TValue> value in data.Values)
				{
					list.AddRange(value);
				}
				return new ReadOnlyCollection<TValue>(list);
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		public void Clear()
		{
			data.Clear();
			count = 0;
			version++;
		}

		public bool Contains(TKey key, TValue value)
		{
			ICollection<TValue> value2;
			if (data.TryGetValue(key, out value2))
			{
				return value2.Contains(value);
			}
			return false;
		}

		public bool ContainsKey(TKey key)
		{
			return data.ContainsKey(key);
		}

		public bool ContainsValue(TValue value)
		{
			foreach (TKey key in data.Keys)
			{
				if (data[key].Contains(value))
				{
					return true;
				}
			}
			return false;
		}

		public ICollection<KeyValuePair<TKey, TValue>> Entries()
		{
			List<KeyValuePair<TKey, TValue>> list = new List<KeyValuePair<TKey, TValue>>(count);
			foreach (KeyValuePair<TKey, ICollection<TValue>> datum in data)
			{
				foreach (TValue item in datum.Value)
				{
					list.Add(new KeyValuePair<TKey, TValue>(datum.Key, item));
				}
			}
			return new ReadOnlyCollection<KeyValuePair<TKey, TValue>>(list);
		}

		public void Add(TKey key, TValue value)
		{
			ICollection<TValue> value2;
			if (!data.TryGetValue(key, out value2))
			{
				value2 = CreateValueCollection();
				data.Add(key, value2);
			}
			value2.Add(value);
			count++;
			version++;
		}

		public void AddAll(TKey key, ICollection<TValue> values)
		{
			ICollection<TValue> value;
			if (!data.TryGetValue(key, out value))
			{
				value = CreateValueCollection();
				data.Add(key, value);
			}
			foreach (TValue value2 in values)
			{
				value.Add(value2);
				count++;
			}
			version++;
		}

		public bool Remove(TKey key, TValue value)
		{
			ICollection<TValue> value2;
			if (!data.TryGetValue(key, out value2))
			{
				return false;
			}
			bool flag = value2.Remove(value);
			if (flag)
			{
				if (value2.Count == 0)
				{
					data.Remove(key);
				}
				count--;
				version++;
			}
			return flag;
		}

		public ICollection<TValue> RemoveAll(TKey key)
		{
			ICollection<TValue> value;
			if (!data.TryGetValue(key, out value))
			{
				return new EmptyCollection<TValue>();
			}
			count -= value.Count;
			data.Remove(key);
			version++;
			return value;
		}

		public void Add(KeyValuePair<TKey, TValue> item)
		{
			Add(item.Key, item.Value);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Clear()
		{
			Clear();
		}

		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			return Contains(item.Key, item.Value);
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			Entries().CopyTo(array, arrayIndex);
		}

		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			return Remove(item.Key, item.Value);
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return new Enumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Enumerator(this);
		}

		protected virtual ICollection<TValue> CreateValueCollection()
		{
			return new List<TValue>();
		}
	}
}
