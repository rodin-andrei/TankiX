using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ModuleVisualEffectObjectsComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public GameObject JumpImpactEffect;

		public GameObject ExternalImpactEffect;

		public GameObject FireRingEffect;

		public GameObject ExplosiveMassEffect;
	}
}
