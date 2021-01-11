using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientMatchMaking.Impl
{
	public class UserEnergyBarUIComponent : BehaviourComponent
	{
		[SerializeField]
		private float animationSpeed = 1f;

		[SerializeField]
		private Slider slider;

		[SerializeField]
		private Slider subSlider;

		[SerializeField]
		private TextMeshProUGUI energyLevel;

		private long currentValue;

		private long maxValue;

		private float mainSliderValue;

		private float subSliderValue;

		private void OnEnable()
		{
			slider.value = 0f;
			subSlider.value = 0f;
		}

		public void SetEnergyLevel(long currentValue, long maxValue)
		{
			this.currentValue = currentValue;
			this.maxValue = maxValue;
			mainSliderValue = (float)currentValue / (float)maxValue;
			subSliderValue = 0f;
			SetTextValue(currentValue, maxValue);
		}

		public void SetSharedEnergyLevel(long sharedValue)
		{
			subSliderValue = (float)currentValue / (float)maxValue;
			mainSliderValue = (float)(currentValue - sharedValue) / (float)maxValue;
			SetTextValue(currentValue - sharedValue, maxValue);
		}

		public void ShowAdditionalEnergyLevel(long additionalValue)
		{
			SetEnergyLevel(currentValue + additionalValue, maxValue);
		}

		private void SetTextValue(long value, long maxValue)
		{
			energyLevel.text = string.Format("{0}/{1}", value, maxValue);
		}

		private void Update()
		{
			LerpSliderValue(slider, mainSliderValue);
			LerpSliderValue(subSlider, subSliderValue);
		}

		private void LerpSliderValue(Slider slider, float value)
		{
			float num = Mathf.Abs(slider.value - value);
			if (num != 0f)
			{
				slider.value = Mathf.Lerp(slider.value, value, Time.deltaTime * animationSpeed / num);
			}
		}
	}
}
