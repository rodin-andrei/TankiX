using System;
using System.Collections.Generic;

namespace Platform.Library.ClientProtocol.API
{
	public class CodecInfoWithAttributes
	{
		private Dictionary<Type, object> attributes;

		public CodecInfo Info
		{
			get;
			private set;
		}

		public CodecInfoWithAttributes()
		{
			attributes = new Dictionary<Type, object>();
		}

		public CodecInfoWithAttributes(CodecInfo info)
			: this()
		{
			Info = info;
		}

		public CodecInfoWithAttributes(Type type, bool optional, bool varied)
			: this(new CodecInfo(type, optional, varied))
		{
		}

		public T GetAttribute<T>() where T : Attribute
		{
			return (T)attributes[typeof(T)];
		}

		public bool IsAttributePresent<T>() where T : Attribute
		{
			return attributes.ContainsKey(typeof(T));
		}

		public void AddAttribute(object attribute)
		{
			attributes.Add(attribute.GetType(), attribute);
		}
	}
}
