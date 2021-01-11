using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientGarage.API;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class TankPartItemPropertiesUIComponent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
	{
		[SerializeField]
		private UpgradePropertyUI propertyUIPreafab;

		[SerializeField]
		private RectTransform contentRect;

		[SerializeField]
		private RectTransform arrowImageRect;

		[SerializeField]
		private float minContentWidth = 400f;

		[SerializeField]
		private float maxContentWidth = 500f;

		[SerializeField]
		private SelectedItemUI selectedItemUI;

		private bool isShow;

		private float arrowInitialScale;

		private bool hover;

		private bool IsShow
		{
			get
			{
				return isShow;
			}
			set
			{
				isShow = value;
				arrowImageRect.localScale = new Vector3(1f, (!isShow) ? arrowInitialScale : (0f - arrowInitialScale), 1f);
			}
		}

		private void OnEnable()
		{
			arrowInitialScale = arrowImageRect.localScale.y;
		}

		public void Show(TankPartItem tankPartItem, float coef, float coefWithSelected)
		{
			if (isShow)
			{
				Hide();
				return;
			}
			if (tankPartItem == null)
			{
				tankPartItem = selectedItemUI.TankPartItem;
			}
			AddProperties(tankPartItem, coef, coefWithSelected);
			contentRect.gameObject.SetActive(true);
			IsShow = true;
		}

		public void Hide()
		{
			contentRect.gameObject.SetActive(false);
			IsShow = false;
		}

		public void AddProperties(TankPartItem tankPartItem, float coef, float selectedCoef)
		{
			Clear();
			bool flag = true;
			foreach (VisualProperty property in tankPartItem.Properties)
			{
				float minValue = property.GetValue(0f) - property.GetValue(0f) / 10f;
				float value = property.GetValue(1f);
				float value2 = property.GetValue(coef);
				string formatedValue = property.GetFormatedValue(coef);
				float value3 = property.GetValue(selectedCoef);
				string formatedValue2 = property.GetFormatedValue(selectedCoef);
				if (value2 == value3)
				{
					GetPropertyUi().SetValue(property.Name, property.Unit, formatedValue);
					continue;
				}
				GetPropertyUi().SetUpgradableValue(property.Name, property.Unit, formatedValue, formatedValue2, value2, value3, minValue, value, property.Format);
				flag = false;
			}
			if (flag)
			{
				contentRect.sizeDelta = new Vector2(minContentWidth, contentRect.sizeDelta.y);
				UpgradePropertyUI[] componentsInChildren = contentRect.GetComponentsInChildren<UpgradePropertyUI>(true);
				UpgradePropertyUI[] array = componentsInChildren;
				foreach (UpgradePropertyUI upgradePropertyUI in array)
				{
					upgradePropertyUI.DisableNextValueAndArrow();
					RectTransform component = upgradePropertyUI.GetComponent<RectTransform>();
					component.sizeDelta = new Vector2(minContentWidth - 20f, component.sizeDelta.y);
				}
			}
			else
			{
				contentRect.sizeDelta = new Vector2(maxContentWidth, contentRect.sizeDelta.y);
			}
		}

		public UpgradePropertyUI GetPropertyUi()
		{
			UpgradePropertyUI upgradePropertyUI = Object.Instantiate(propertyUIPreafab);
			upgradePropertyUI.gameObject.SetActive(true);
			upgradePropertyUI.transform.SetParent(contentRect, false);
			return upgradePropertyUI;
		}

		public void Clear()
		{
			UpgradePropertyUI[] componentsInChildren = contentRect.GetComponentsInChildren<UpgradePropertyUI>(true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].transform.SetParent(null);
				Object.Destroy(componentsInChildren[i].gameObject);
			}
		}

		private void Update()
		{
			if (IsShow && (InputMapping.Cancel || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) && !hover)
			{
				Hide();
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			hover = true;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			hover = false;
		}
	}
}
