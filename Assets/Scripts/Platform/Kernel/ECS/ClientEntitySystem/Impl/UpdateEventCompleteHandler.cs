using System.Reflection;
using System;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class UpdateEventCompleteHandler : EventCompleteHandler
	{
		public UpdateEventCompleteHandler(MethodInfo method, MethodHandle methodHandle, HandlerArgumentsDescription handlerArgumentsDescription) : base(default(Type), default(MethodInfo), default(MethodHandle), default(HandlerArgumentsDescription))
		{
		}

	}
}
