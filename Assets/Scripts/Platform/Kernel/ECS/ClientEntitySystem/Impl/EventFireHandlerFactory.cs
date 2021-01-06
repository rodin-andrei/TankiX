using System;
using System.Collections.Generic;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class EventFireHandlerFactory : AbstractHandlerFactory
	{
		public EventFireHandlerFactory() : base(default(Type), default(IList<Type>))
		{
		}

	}
}
