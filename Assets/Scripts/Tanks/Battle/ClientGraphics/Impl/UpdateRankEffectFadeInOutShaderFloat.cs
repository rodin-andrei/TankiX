using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class UpdateRankEffectFadeInOutShaderFloat : MonoBehaviour
	{
		public string PropertyName;
		public float MaxFloat;
		public float StartDelay;
		public float FadeInSpeed;
		public float FadeOutDelay;
		public float FadeOutSpeed;
		public bool FadeOutAfterCollision;
		public bool UseHideStatus;
	}
}
