using System.Reflection;
using System;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class NodeRemovedFireHandler : EventFireHandler
	{
		public NodeRemovedFireHandler(MethodInfo method, MethodHandle methodHandle, HandlerArgumentsDescription handlerArgumentsDescription) : base(default(Type), default(MethodInfo), default(MethodHandle), default(HandlerArgumentsDescription))
		{
		}

	}
}