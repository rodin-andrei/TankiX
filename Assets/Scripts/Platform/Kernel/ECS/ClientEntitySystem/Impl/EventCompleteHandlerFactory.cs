using System;
using System.Collections.Generic;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class EventCompleteHandlerFactory : AbstractHandlerFactory
	{
		public EventCompleteHandlerFactory() : base(default(Type), default(IList<Type>))
		{
		}

	}
}
