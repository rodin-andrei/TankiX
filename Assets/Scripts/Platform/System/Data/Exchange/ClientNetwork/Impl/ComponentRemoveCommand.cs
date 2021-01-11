using System;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.ECS.ClientEntitySystem.Impl;

namespace Platform.System.Data.Exchange.ClientNetwork.Impl
{
	public class ComponentRemoveCommand : ComponentCommand
	{
		public ComponentRemoveCommand()
		{
		}

		public ComponentRemoveCommand(Entity entity, Type componentType)
			: base(entity, componentType)
		{
		}

		public ComponentRemoveCommand Init(Entity entity, Type componentType)
		{
			base.ComponentType = componentType;
			base.Entity = (EntityInternal)entity;
			return this;
		}

		public override void Execute(Engine engine)
		{
			base.Entity.RemoveComponentSilent(base.ComponentType);
		}

		public override string ToString()
		{
			return string.Format("ComponentRemoveCommand Entity={0} ComponentType={1}", base.Entity, base.ComponentType);
		}
	}
}
