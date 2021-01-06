using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class TankDeadStateTextureComponent : MonoBehaviour
	{
		[SerializeField]
		private Texture2D deadColorTexture;
		[SerializeField]
		private Texture2D deadEmissionTexture;
		[SerializeField]
		private AnimationCurve heatEmission;
		[SerializeField]
		private AnimationCurve whiteToHeat;
		[SerializeField]
		private AnimationCurve paintToHeat;
	}
}
