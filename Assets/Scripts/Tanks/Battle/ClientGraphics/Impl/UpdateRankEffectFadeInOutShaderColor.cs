using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class UpdateRankEffectFadeInOutShaderColor : MonoBehaviour
	{
		public string ShaderColorName;
		public float StartDelay;
		public float FadeInSpeed;
		public float FadeOutDelay;
		public float FadeOutSpeed;
		public bool UseSharedMaterial;
		public bool FadeOutAfterCollision;
		public bool UseHideStatus;
	}
}
