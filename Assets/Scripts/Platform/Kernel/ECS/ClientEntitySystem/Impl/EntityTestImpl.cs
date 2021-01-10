using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class EntityTestImpl : EntityImpl
	{
		public EntityTestImpl(EngineServiceInternal engineService, long id, string name) : base(default(EngineServiceInternal), default(long), default(string))
		{
		}

	}
}
