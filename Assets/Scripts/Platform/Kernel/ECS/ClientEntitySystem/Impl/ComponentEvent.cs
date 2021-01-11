using System;
using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public abstract class ComponentEvent : Event
	{
		public Type ComponentType
		{
			get;
			private set;
		}

		protected ComponentEvent(Type componentType)
		{
			ComponentType = componentType;
		}
	}
}
