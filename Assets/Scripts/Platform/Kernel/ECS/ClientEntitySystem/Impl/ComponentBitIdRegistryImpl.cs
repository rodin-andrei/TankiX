using Platform.Library.ClientDataStructures.API;
using System;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class ComponentBitIdRegistryImpl : TypeByIdRegistry
	{
		public ComponentBitIdRegistryImpl() : base(default(Func<Type, long>))
		{
		}

	}
}
