using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class AnimatedPropertyProgressBar : MonoBehaviour
	{
		private bool canStart;

		private float finalValue;

		[SerializeField]
		private Image slider;

		private void Start()
		{
			finalValue = slider.fillAmount;
			slider.fillAmount = 0f;
			canStart = true;
		}

		private void Update()
		{
			if (canStart)
			{
				slider.fillAmount = Mathf.Lerp(slider.fillAmount, finalValue, 0.1f);
				if (slider.fillAmount == finalValue)
				{
					canStart = false;
				}
			}
		}

		private void OnDisable()
		{
			slider.fillAmount = 0f;
		}
	}
}
