using System.Reflection;
using System;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class UpdateEventFireHandler : EventFireHandler
	{
		public UpdateEventFireHandler(MethodInfo method, MethodHandle methodHandle, HandlerArgumentsDescription handlerArgumentsDescription) : base(default(Type), default(MethodInfo), default(MethodHandle), default(HandlerArgumentsDescription))
		{
		}

	}
}
