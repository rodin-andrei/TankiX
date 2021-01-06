using System;
using System.Collections.Generic;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class ConcreteEventHandlerFactory : AbstractHandlerFactory
	{
		protected ConcreteEventHandlerFactory(Type annotationEventClass, Type parameterClass) : base(default(Type), default(IList<Type>))
		{
		}

	}
}
