using System.Reflection;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class EventAbsentInArgumentHandlerFactoryException : HandlerFactoryException
	{
		public EventAbsentInArgumentHandlerFactoryException(MethodInfo method) : base(default(MethodInfo))
		{
		}

	}
}
