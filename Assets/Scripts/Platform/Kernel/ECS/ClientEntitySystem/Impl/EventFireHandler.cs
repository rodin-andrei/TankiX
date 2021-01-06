using System;
using System.Reflection;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class EventFireHandler : Handler
	{
		public EventFireHandler(Type eventType, MethodInfo method, MethodHandle methodHandle, HandlerArgumentsDescription handlerArgumentsDescription) : base(default(EventPhase), default(Type), default(MethodInfo), default(MethodHandle), default(HandlerArgumentsDescription))
		{
		}

	}
}
