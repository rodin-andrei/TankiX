using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.ECS.ClientEntitySystem.Impl;
using Platform.Library.ClientProtocol.API;

namespace Platform.System.Data.Exchange.ClientNetwork.Impl
{
	public class ComponentChangeCommand : EntityCommand
	{
		[ProtocolVaried]
		[ProtocolParameterOrder(1)]
		public Component Component
		{
			get;
			set;
		}

		public ComponentChangeCommand()
		{
		}

		public ComponentChangeCommand(Entity entity, Component component)
			: base(entity)
		{
			Component = component;
		}

		public ComponentChangeCommand Init(Entity entity, Component component)
		{
			Component = component;
			base.Entity = (EntityInternal)entity;
			return this;
		}

		public override void Execute(Engine engine)
		{
			ApplyChange(engine);
		}

		private void ApplyChange(Engine engine)
		{
			((EntityImpl)base.Entity).ChangeComponent(Component);
		}

		public override string ToString()
		{
			return string.Format("ComponentChangeCommand Entity={0} Component={1}", base.Entity, EcsToStringUtil.ToStringWithProperties(Component));
		}
	}
}
