using System.Reflection;
using System;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class TimeUpdateFireHandler : EventFireHandler
	{
		public TimeUpdateFireHandler(MethodInfo method, MethodHandle methodHandle, HandlerArgumentsDescription handlerArgumentsDescription) : base(default(Type), default(MethodInfo), default(MethodHandle), default(HandlerArgumentsDescription))
		{
		}

	}
}