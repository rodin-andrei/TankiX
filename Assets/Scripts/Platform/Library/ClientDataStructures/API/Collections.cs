using System;
using System.Collections.Generic;
using Platform.Library.ClientDataStructures.Impl;

namespace Platform.Library.ClientDataStructures.API
{
	public class Collections
	{
		public struct Enumerator<T>
		{
			private IEnumerable<T> collection;

			private HashSet<T>.Enumerator hashSetEnumerator;

			private List<T>.Enumerator ListEnumerator;

			private IEnumerator<T> enumerator;

			public T Current
			{
				get
				{
					if (collection is List<T>)
					{
						return ListEnumerator.Current;
					}
					if (collection is HashSet<T>)
					{
						return hashSetEnumerator.Current;
					}
					return enumerator.Current;
				}
			}

			public Enumerator(IEnumerable<T> collection)
			{
				this.collection = collection;
				enumerator = null;
				List<T> list;
				HashSet<T> hashSet;
				if ((list = collection as List<T>) != null)
				{
					ListEnumerator = list.GetEnumerator();
					hashSetEnumerator = default(HashSet<T>.Enumerator);
				}
				else if ((hashSet = collection as HashSet<T>) != null)
				{
					hashSetEnumerator = hashSet.GetEnumerator();
					ListEnumerator = default(List<T>.Enumerator);
				}
				else
				{
					hashSetEnumerator = default(HashSet<T>.Enumerator);
					ListEnumerator = default(List<T>.Enumerator);
					enumerator = collection.GetEnumerator();
				}
			}

			public bool MoveNext()
			{
				if (collection is List<T>)
				{
					return ListEnumerator.MoveNext();
				}
				if (collection is HashSet<T>)
				{
					return hashSetEnumerator.MoveNext();
				}
				return enumerator.MoveNext();
			}
		}

		public static readonly object[] EmptyArray = new object[0];

		public static IList<T> EmptyList<T>()
		{
			return Platform.Library.ClientDataStructures.Impl.EmptyList<T>.Instance;
		}

		public static List<T> AsList<T>(params T[] values)
		{
			return new List<T>(values);
		}

		public static IList<T> SingletonList<T>(T value)
		{
			return new SingletonList<T>(value);
		}

		public static T GetOnlyElement<T>(ICollection<T> coll)
		{
			if (coll.Count != 1)
			{
				throw new InvalidOperationException("Count: " + coll.Count);
			}
			List<T> list;
			if ((list = coll as List<T>) != null)
			{
				return list[0];
			}
			HashSet<T> hashSet;
			if ((hashSet = coll as HashSet<T>) != null)
			{
				HashSet<T>.Enumerator enumerator = hashSet.GetEnumerator();
				enumerator.MoveNext();
				return enumerator.Current;
			}
			IEnumerator<T> enumerator2 = coll.GetEnumerator();
			enumerator2.MoveNext();
			return enumerator2.Current;
		}

		public static Enumerator<T> GetEnumerator<T>(IEnumerable<T> collection)
		{
			return new Enumerator<T>(collection);
		}

		public static void ForEach<T>(IEnumerable<T> coll, Action<T> action)
		{
			Enumerator<T> enumerator = GetEnumerator(coll);
			while (enumerator.MoveNext())
			{
				action(enumerator.Current);
			}
		}
	}
}
