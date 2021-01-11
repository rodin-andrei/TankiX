using UnityEngine;
using UnityEngine.UI;

namespace tanks.modules.tool.TankViewer.Scripts.API.ColoringEditor.ParamView
{
	public class IntensityThresholdView : MonoBehaviour
	{
		public Toggle toggle;

		public Slider slider;

		public void SetUseIntensityThreshold(bool value)
		{
			toggle.isOn = value;
		}

		public bool GetUseIntensityThreshold()
		{
			return toggle.isOn;
		}

		public void SetIntensityThreshold(float value)
		{
			slider.value = value;
		}

		public float GetIntensityThreshold()
		{
			return slider.value;
		}

		public void OnToggleChanged()
		{
			Enable();
		}

		public void Enable()
		{
			toggle.interactable = true;
			slider.interactable = toggle.isOn;
		}

		public void Disable()
		{
			toggle.interactable = false;
			slider.interactable = false;
		}
	}
}
