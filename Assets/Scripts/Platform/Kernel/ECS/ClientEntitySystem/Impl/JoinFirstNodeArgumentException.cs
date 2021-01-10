using System;
using System.Reflection;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class JoinFirstNodeArgumentException : Exception
	{
		public JoinFirstNodeArgumentException(MethodInfo method, HandlerArgument handlerArgument)
		{
		}

	}
}
