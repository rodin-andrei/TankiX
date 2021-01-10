using System;
using System.Reflection;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class HandlerFactoryException : Exception
	{
		public HandlerFactoryException(MethodInfo method)
		{
		}

	}
}
