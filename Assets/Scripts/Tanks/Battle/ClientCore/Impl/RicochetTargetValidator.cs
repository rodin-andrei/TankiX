using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class RicochetTargetValidator : TargetValidator
	{
		public RicochetTargetValidator(Entity ownerEntity, float bulletRadius) : base(default(Entity))
		{
		}

	}
}
