using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.System.Data.Statics.ClientYaml.API;

namespace Platform.System.Data.Statics.ClientYaml.Impl
{
	public class YamlNodeImpl : YamlNode
	{
		public class Comparer : IEqualityComparer<Type>
		{
			public bool Equals(Type x, Type y)
			{
				return x.FullName.Equals(y.FullName);
			}

			public int GetHashCode(Type obj)
			{
				return obj.GetHashCode();
			}
		}

		public Dictionary<object, object> innerDictionary;

		public Dictionary<Type, object> typeToPrototypeCache = new Dictionary<Type, object>(new Comparer());

		public Dictionary<string, YamlNode> keyToChildNode = new Dictionary<string, YamlNode>();

		private bool noClone;

		[Inject]
		public static YamlService YamlService
		{
			get;
			set;
		}

		public YamlNodeImpl(Dictionary<object, object> innerDictionary)
		{
			this.innerDictionary = innerDictionary;
		}

		public YamlNode GetChildNode(string key)
		{
			YamlNode value;
			if (!keyToChildNode.TryGetValue(key, out value))
			{
				value = new YamlNodeImpl(CastValueTo<Dictionary<object, object>>(key));
				keyToChildNode.Add(key, value);
			}
			return value;
		}

		public List<T> GetList<T>(string key)
		{
			return GetListContentsOf<T>(key).ToList();
		}

		public List<YamlNode> GetChildListNodes(string key)
		{
			return (from x in GetListContentsOf<Dictionary<object, object>>(key)
				select new YamlNodeImpl(x)).Cast<YamlNode>().ToList();
		}

		public List<string> GetChildListValues(string key)
		{
			return GetListContentsOf<string>(key).ToList();
		}

		private IEnumerable<T> GetListContentsOf<T>(string key)
		{
			List<object> source = CastValueTo<List<object>>(key);
			if (!source.All((object x) => x is T))
			{
				throw new WrongYamlStructureException("element of " + key, typeof(T), typeof(object));
			}
			return source.Cast<T>();
		}

		public string GetStringValue(string key)
		{
			return CastValueTo<string>(key);
		}

		public object GetValue(string key)
		{
			return innerDictionary[key];
		}

		public object GetValueOrNull(string key)
		{
			object value;
			if (innerDictionary.TryGetValue(key, out value))
			{
				return value;
			}
			return null;
		}

		public ICollection<string> GetKeys()
		{
			return new List<string>(innerDictionary.Keys.Select((object k) => k.ToString()));
		}

		public bool HasValue(string key)
		{
			return innerDictionary.ContainsKey(key);
		}

		public T ConvertTo<T>()
		{
			return (T)ConvertTo(typeof(T));
		}

		public object ConvertTo(Type t)
		{
			object objectPrototypeForType = GetObjectPrototypeForType(t);
			if (noClone)
			{
				return objectPrototypeForType;
			}
			return CloneObjectUtil.CloneObject(objectPrototypeForType);
		}

		public void PreloadObject(Type type, bool noCloneOnConvert)
		{
			GetObjectPrototypeForType(type);
			noClone = noCloneOnConvert;
		}

		private object GetObjectPrototypeForType(Type t)
		{
			object value;
			typeToPrototypeCache.TryGetValue(t, out value);
			if (value == null)
			{
				value = YamlService.Load(this, t);
				typeToPrototypeCache.Add(t, value);
			}
			return value;
		}

		public void Merge(YamlNodeImpl yamlNode)
		{
			MergeDictionary(innerDictionary, yamlNode.innerDictionary);
		}

		public void MergeDictionary(IDictionary destination, IDictionary source)
		{
			IDictionaryEnumerator enumerator = source.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					DictionaryEntry dictionaryEntry = (DictionaryEntry)enumerator.Current;
					destination[dictionaryEntry.Key] = MergeValue(dictionaryEntry.Key, destination[dictionaryEntry.Key], dictionaryEntry.Value);
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = enumerator as IDisposable) != null)
				{
					disposable.Dispose();
				}
			}
		}

		private object MergeValue(object key, object destValue, object sourceValue)
		{
			if (destValue == null)
			{
				return sourceValue;
			}
			if (destValue.GetType() != sourceValue.GetType())
			{
				throw new MergingYamlMismatchException((string)key, destValue.GetType(), sourceValue.GetType());
			}
			if (destValue is IDictionary)
			{
				MergeDictionary((IDictionary)destValue, (IDictionary)sourceValue);
			}
			else
			{
				if (!(destValue is IList))
				{
					return sourceValue;
				}
				MergeList((IList)destValue, (IList)sourceValue);
			}
			return destValue;
		}

		private void MergeList(IList destination, IList source)
		{
			IEnumerator enumerator = source.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object current = enumerator.Current;
					destination.Add(current);
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = enumerator as IDisposable) != null)
				{
					disposable.Dispose();
				}
			}
		}

		public T CastValueTo<T>(string key)
		{
			object value;
			if (!innerDictionary.TryGetValue(key, out value))
			{
				throw new UnknownYamlKeyException(key);
			}
			CheckType(key, typeof(T), value);
			return (T)value;
		}

		private void CheckType(string key, Type type, object value)
		{
			if (type != null && !type.IsInstanceOfType(value))
			{
				throw new WrongYamlStructureException(key, type, value.GetType());
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<object, object> item in innerDictionary)
			{
				stringBuilder.AppendFormat("{0}: {1}, ", item.Key, item.Value);
			}
			return stringBuilder.ToString().TrimEnd(",".ToCharArray());
		}
	}
}
