using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class WeaponEnergyFeedbackFadeBehaviour : MonoBehaviour
	{
		private const float FADE_OUT_TIME = 0.5f;

		private const float FADE_OUT_SPEED = 2f;

		[SerializeField]
		private AudioSource source;

		private void Update()
		{
			source.volume -= 2f * Time.deltaTime;
		}
	}
}
