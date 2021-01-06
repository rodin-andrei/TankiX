using System;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class WrongNodeFieldNameException : Exception
	{
		public WrongNodeFieldNameException(Type nodeClass, Type fieldType, string fieldName)
		{
		}

	}
}
