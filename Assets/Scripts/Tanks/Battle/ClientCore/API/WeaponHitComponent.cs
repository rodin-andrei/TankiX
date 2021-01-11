using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientCore.API
{
	public class WeaponHitComponent : Component
	{
		public bool SendStaticHit
		{
			get;
			set;
		}

		public bool RemoveDuplicateTargets
		{
			get;
			set;
		}

		public WeaponHitComponent(bool sendStaticHit, bool removeDuplicateTargets)
		{
			SendStaticHit = sendStaticHit;
			RemoveDuplicateTargets = removeDuplicateTargets;
		}
	}
}
