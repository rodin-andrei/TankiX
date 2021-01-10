using System;
using System.Reflection;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class JoinToCollectionException : Exception
	{
		public JoinToCollectionException(MethodInfo method, HandlerArgument handlerArgument)
		{
		}

	}
}
