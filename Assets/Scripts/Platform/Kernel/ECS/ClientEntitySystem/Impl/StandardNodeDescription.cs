using System;
using System.Collections.Generic;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class StandardNodeDescription : AbstractNodeDescription
	{
		public StandardNodeDescription(Type nodeClass, ICollection<Type> additionalComponents) : base(default(ICollection<Type>))
		{
		}

	}
}
