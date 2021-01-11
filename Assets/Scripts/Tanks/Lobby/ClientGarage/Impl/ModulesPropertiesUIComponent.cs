using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ModulesPropertiesUIComponent : BehaviourComponent
	{
		[SerializeField]
		private UpgradePropertyUI propertyUIPreafab;

		[SerializeField]
		private RectTransform scrollContent;

		public void AddProperty(string name, string unit, float minValue, float maxValue, float currentValue, float nextValue, string format)
		{
			if (currentValue != nextValue)
			{
				GetPropertyUi().SetUpgradableValue(name, unit, minValue, maxValue, currentValue, nextValue, format);
			}
			else
			{
				AddProperty(name, unit, currentValue, format);
			}
		}

		public void AddProperty(string name, string unit, string currentValueStr, string nextValueStr, float minValue, float maxValue, float currentValue, float nextValue, string format)
		{
			if (currentValue != nextValue)
			{
				GetPropertyUi().SetUpgradableValue(name, unit, currentValueStr, nextValueStr, currentValue, nextValue, minValue, maxValue, format);
			}
			else
			{
				GetPropertyUi().SetValue(name, unit, currentValueStr);
			}
		}

		public void AddProperty(string name, string unit, float currentValue, string format)
		{
			GetPropertyUi().SetValue(name, unit, currentValue, format);
		}

		public UpgradePropertyUI GetPropertyUi()
		{
			UpgradePropertyUI upgradePropertyUI = Object.Instantiate(propertyUIPreafab);
			upgradePropertyUI.gameObject.SetActive(true);
			upgradePropertyUI.transform.SetParent(scrollContent, false);
			return upgradePropertyUI;
		}

		public void Clear()
		{
			scrollContent.DestroyChildren();
		}
	}
}
