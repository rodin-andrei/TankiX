using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ShaftAimingRendererEffectComponent : MonoBehaviour
	{
		[SerializeField]
		private int transparentRenderQueue;
		[SerializeField]
		private float alphaRecoveringSpeed;
	}
}
