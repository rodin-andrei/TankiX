using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class HandlerBroadcastInvokeData : HandlerInvokeData
	{
		private readonly Entity entity;

		public Entity Entity
		{
			get
			{
				return entity;
			}
		}

		public HandlerBroadcastInvokeData(Handler handler, Entity entity)
			: base(handler)
		{
			this.entity = entity;
		}
	}
}
