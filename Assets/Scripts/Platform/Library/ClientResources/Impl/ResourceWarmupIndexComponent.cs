using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Platform.Library.ClientResources.Impl
{
	public class ResourceWarmupIndexComponent : Component
	{
		public int Index
		{
			get;
			set;
		}

		public ResourceWarmupIndexComponent()
		{
			Index = 0;
		}
	}
}
