using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ShaftAimingRendererEffectComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private int transparentRenderQueue = 3000;

		[SerializeField]
		private float alphaRecoveringSpeed = 2f;

		public float AlphaRecoveringSpeed
		{
			get
			{
				return alphaRecoveringSpeed;
			}
			set
			{
				alphaRecoveringSpeed = value;
			}
		}

		public int TransparentRenderQueue
		{
			get
			{
				return transparentRenderQueue;
			}
			set
			{
				transparentRenderQueue = value;
			}
		}
	}
}
