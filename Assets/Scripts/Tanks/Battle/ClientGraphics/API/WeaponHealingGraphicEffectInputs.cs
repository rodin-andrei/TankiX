using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public class WeaponHealingGraphicEffectInputs : HealingGraphicEffectInputs
	{
		private Transform rotationTransform;

		public Transform RotationTransform
		{
			get
			{
				return rotationTransform;
			}
		}

		public override float TilingX
		{
			get
			{
				return 2f;
			}
		}

		public WeaponHealingGraphicEffectInputs(Entity entity, Transform rotationTransform, SkinnedMeshRenderer renderer)
			: base(entity, renderer)
		{
			this.rotationTransform = rotationTransform;
		}
	}
}
