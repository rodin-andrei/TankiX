using System.Reflection;
using System;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class NodeRemovedCompleteHandler : EventCompleteHandler
	{
		public NodeRemovedCompleteHandler(MethodInfo method, MethodHandle methodHandle, HandlerArgumentsDescription handlerArgumentsDescription) : base(default(Type), default(MethodInfo), default(MethodHandle), default(HandlerArgumentsDescription))
		{
		}

	}
}
