using System.Collections;
using System.Collections.Generic;
using Platform.Library.ClientDataStructures.Impl;

namespace Platform.Library.ClientDataStructures.API
{
	public class HashBiMap<TKey, TValue> : IBiMap<TKey, TValue>, IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
	{
		private class InverseBiMap<TValue, TKey> : IBiMap<TValue, TKey>, IDictionary<TValue, TKey>, ICollection<KeyValuePair<TValue, TKey>>, IEnumerable<KeyValuePair<TValue, TKey>>, IEnumerable
		{
			internal Dictionary<TValue, TKey> inverseData;

			private IBiMap<TKey, TValue> direct;

			public int Count
			{
				get
				{
					return direct.Count;
				}
			}

			public IBiMap<TKey, TValue> Inverse
			{
				get
				{
					return direct;
				}
			}

			public bool IsReadOnly
			{
				get
				{
					return false;
				}
			}

			public TKey this[TValue _value]
			{
				get
				{
					TKey value;
					if (inverseData.TryGetValue(_value, out value))
					{
						return value;
					}
					throw new ValueNotFoundException(_value);
				}
				set
				{
					direct.ForcePut(value, _value);
				}
			}

			public ICollection<TValue> Keys
			{
				get
				{
					return inverseData.Keys;
				}
			}

			public ICollection<TKey> Values
			{
				get
				{
					return inverseData.Values;
				}
			}

			public InverseBiMap(IBiMap<TKey, TValue> direct)
			{
				inverseData = new Dictionary<TValue, TKey>();
				this.direct = direct;
			}

			public IEnumerator<KeyValuePair<TValue, TKey>> GetEnumerator()
			{
				return inverseData.GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}

			public void Add(KeyValuePair<TValue, TKey> item)
			{
				direct.Add(item.Value, item.Key);
			}

			public void Clear()
			{
				direct.Clear();
			}

			public bool Contains(KeyValuePair<TValue, TKey> item)
			{
				return direct.Contains(item.Value, item.Key);
			}

			public bool Contains(TValue value, TKey key)
			{
				return direct.Contains(key, value);
			}

			public void CopyTo(KeyValuePair<TValue, TKey>[] array, int arrayIndex)
			{
				((ICollection<KeyValuePair<TValue, TKey>>)inverseData).CopyTo(array, arrayIndex);
			}

			public bool ContainsKey(TValue value)
			{
				return inverseData.ContainsKey(value);
			}

			public void Add(TValue value, TKey key)
			{
				direct.Add(key, value);
			}

			public bool Remove(TValue value)
			{
				TKey value2;
				if (inverseData.TryGetValue(value, out value2))
				{
					return direct.Remove(value2);
				}
				return false;
			}

			public bool Remove(KeyValuePair<TValue, TKey> item)
			{
				return direct.Remove(item.Value, item.Key);
			}

			public bool Remove(TValue value, TKey key)
			{
				return direct.Remove(key, value);
			}

			public bool TryGetValue(TValue value, out TKey key)
			{
				return inverseData.TryGetValue(value, out key);
			}

			public void ForcePut(TValue value, TKey key)
			{
				direct.ForcePut(key, value);
			}
		}

		private Dictionary<TKey, TValue> data = new Dictionary<TKey, TValue>();

		private InverseBiMap<TValue, TKey> inverse;

		public int Count
		{
			get
			{
				return data.Count;
			}
		}

		public IBiMap<TValue, TKey> Inverse
		{
			get
			{
				return inverse;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return false;
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
				return data.Values;
			}
		}

		public TValue this[TKey key]
		{
			get
			{
				TValue value;
				if (data.TryGetValue(key, out value))
				{
					return value;
				}
				throw new Platform.Library.ClientDataStructures.Impl.KeyNotFoundException(key);
			}
			set
			{
				ForcePut(key, value);
			}
		}

		public HashBiMap()
		{
			inverse = new InverseBiMap<TValue, TKey>(this);
		}

		public void Add(KeyValuePair<TKey, TValue> item)
		{
			Add(item.Key, item.Value);
		}

		public void Add(TKey key, TValue value)
		{
			CheckNotNulls(key, value);
			if (data.ContainsKey(key))
			{
				throw new KeyAlreadyExistsException(key);
			}
			if (inverse.inverseData.ContainsKey(value))
			{
				throw new ValueAlreadyExistsException(value);
			}
			data.Add(key, value);
			inverse.inverseData.Add(value, key);
		}

		public void ForcePut(TKey key, TValue value)
		{
			CheckNotNulls(key, value);
			TValue value2;
			if (data.TryGetValue(key, out value2))
			{
				data.Remove(key);
				inverse.inverseData.Remove(value2);
			}
			TKey value3;
			if (inverse.inverseData.TryGetValue(value, out value3))
			{
				inverse.inverseData.Remove(value);
				data.Remove(value3);
			}
			data.Add(key, value);
			inverse.inverseData.Add(value, key);
		}

		public void Clear()
		{
			data.Clear();
			inverse.inverseData.Clear();
		}

		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			return Contains(item.Key, item.Value);
		}

		public bool Contains(TKey key, TValue value)
		{
			TValue value2;
			if (data.TryGetValue(key, out value2))
			{
				return object.Equals(value, value2);
			}
			return false;
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			((ICollection<KeyValuePair<TKey, TValue>>)data).CopyTo(array, arrayIndex);
		}

		public bool ContainsKey(TKey key)
		{
			return data.ContainsKey(key);
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return data.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public bool Remove(TKey key)
		{
			TValue value;
			if (data.TryGetValue(key, out value))
			{
				data.Remove(key);
				inverse.inverseData.Remove(value);
				return true;
			}
			return false;
		}

		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			return Remove(item.Key, item.Value);
		}

		public bool Remove(TKey key, TValue value)
		{
			TValue value2;
			if (data.TryGetValue(key, out value2) && object.Equals(value, value2))
			{
				data.Remove(key);
				inverse.inverseData.Remove(value);
				return true;
			}
			return false;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			return data.TryGetValue(key, out value);
		}

		private void CheckNotNulls(TKey key, TValue value)
		{
			if (key == null)
			{
				throw new KeyIsNullExcpetion();
			}
			if (value == null)
			{
				throw new ValueIsNullException();
			}
		}
	}
}
