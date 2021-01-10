using System;
using System.Reflection;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class PrivateHandlerFoundException : Exception
	{
		public PrivateHandlerFoundException(MethodInfo method)
		{
		}

	}
}
