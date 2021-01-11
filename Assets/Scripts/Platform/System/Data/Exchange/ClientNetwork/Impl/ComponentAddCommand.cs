using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.ECS.ClientEntitySystem.Impl;
using Platform.Library.ClientProtocol.API;

namespace Platform.System.Data.Exchange.ClientNetwork.Impl
{
	public class ComponentAddCommand : EntityCommand
	{
		[ProtocolVaried]
		[ProtocolParameterOrder(1)]
		public Component Component
		{
			get;
			set;
		}

		public ComponentAddCommand()
		{
		}

		public ComponentAddCommand(Entity entity, Component component)
			: base(entity)
		{
			Component = component;
		}

		public ComponentAddCommand Init(Entity entity, Component component)
		{
			Component = component;
			base.Entity = (EntityInternal)entity;
			return this;
		}

		public override void Execute(Engine engine)
		{
			base.Entity.AddComponentSilent(Component);
		}

		protected bool Equals(ComponentAddCommand other)
		{
			return Component == other.Component;
		}

		public override bool Equals(object obj)
		{
			if (object.ReferenceEquals(null, obj))
			{
				return false;
			}
			if (object.ReferenceEquals(this, obj))
			{
				return true;
			}
			if (obj.GetType() != GetType())
			{
				return false;
			}
			return Equals((ComponentAddCommand)obj);
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return string.Format("ComponentAddCommand: Entity={0} Component={1}", base.Entity, Component);
		}
	}
}
