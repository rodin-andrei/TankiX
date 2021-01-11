using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class CharacterShadowInternalComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Projector Projector
		{
			get;
			set;
		}

		public Material CasterMaterial
		{
			get;
			set;
		}

		public float BaseAlpha
		{
			get;
			set;
		}

		public Bounds ProjectionBoundInLightSpace
		{
			get;
			set;
		}
	}
}
