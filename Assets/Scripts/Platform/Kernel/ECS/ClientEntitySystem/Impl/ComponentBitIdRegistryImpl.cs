using System;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientDataStructures.API;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class ComponentBitIdRegistryImpl : TypeByIdRegistry, ComponentBitIdRegistry, EngineHandlerRegistrationListener
	{
		private static long bitSequence;

		public ComponentBitIdRegistryImpl()
			: base(GetNextBitNumber)
		{
		}

		private static long GetNextBitNumber(Type clazz)
		{
			return ++bitSequence;
		}

		public void OnHandlerAdded(Handler handler)
		{
			handler.HandlerArgumentsDescription.ComponentClasses.ForEach(delegate(Type t)
			{
				Register(t);
			});
		}

		public int GetComponentBitId(Type componentClass)
		{
			return (int)GetId(componentClass);
		}
	}
}
