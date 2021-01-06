using System;
using System.Reflection;

namespace Platform.Library.ClientProtocol.Impl
{
	public class StructEncodeException : Exception
	{
		public StructEncodeException(Type structType, PropertyInfo prop, Exception e)
		{
		}

	}
}
