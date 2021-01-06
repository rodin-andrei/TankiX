using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public class WeaponHealingGraphicEffectInputs : HealingGraphicEffectInputs
	{
		public WeaponHealingGraphicEffectInputs(Entity entity, Transform rotationTransform, SkinnedMeshRenderer renderer) : base(default(Entity), default(SkinnedMeshRenderer))
		{
		}

	}
}
