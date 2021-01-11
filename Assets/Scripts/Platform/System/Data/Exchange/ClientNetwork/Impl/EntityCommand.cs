using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.ECS.ClientEntitySystem.Impl;
using Platform.Library.ClientProtocol.API;

namespace Platform.System.Data.Exchange.ClientNetwork.Impl
{
	public abstract class EntityCommand : AbstractCommand
	{
		[ProtocolParameterOrder(0)]
		public EntityInternal Entity
		{
			get;
			set;
		}

		public EntityCommand()
		{
		}

		public EntityCommand(Entity entity)
		{
			Entity = (EntityInternal)entity;
		}
	}
}
