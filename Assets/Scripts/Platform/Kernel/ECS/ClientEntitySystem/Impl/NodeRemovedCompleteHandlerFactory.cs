using System.Reflection;
using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class NodeRemovedCompleteHandlerFactory : ConcreteEventHandlerFactory
	{
		public NodeRemovedCompleteHandlerFactory()
			: base(typeof(OnEventComplete), typeof(NodeRemoveEvent))
		{
		}

		protected override Handler CreateHandlerInstance(MethodInfo method, MethodHandle methodHandle, HandlerArgumentsDescription handlerArgumentsDescription)
		{
			return new NodeRemovedCompleteHandler(method, methodHandle, handlerArgumentsDescription);
		}
	}
}
