using System.Collections.Generic;

namespace Platform.Library.ClientDataStructures.API
{
	public class Pair<K, V>
	{
		public V Value
		{
			get;
			set;
		}

		public K Key
		{
			get;
			set;
		}

		public Pair(K k, V v)
		{
			Key = k;
			Value = v;
		}

		protected bool Equals(Pair<K, V> other)
		{
			return EqualityComparer<V>.Default.Equals(Value, other.Value) && EqualityComparer<K>.Default.Equals(Key, other.Key);
		}

		public override bool Equals(object obj)
		{
			if (object.ReferenceEquals(null, obj))
			{
				return false;
			}
			if (object.ReferenceEquals(this, obj))
			{
				return true;
			}
			if (obj.GetType() != GetType())
			{
				return false;
			}
			return Equals((Pair<K, V>)obj);
		}

		public override int GetHashCode()
		{
			return (EqualityComparer<V>.Default.GetHashCode(Value) * 397) ^ EqualityComparer<K>.Default.GetHashCode(Key);
		}
	}
}
