using System;
using System.Collections;
using System.Collections.Generic;
using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class SelectCountryDialogComponent : ConfirmDialogComponent
	{
		[SerializeField]
		private ScrollRect scrollRect;

		[SerializeField]
		private SelectCountryItem itemPrefab;

		[SerializeField]
		private TMP_InputField searchInput;

		public KeyValuePair<string, string> country;

		private string filterString = string.Empty;

		public string FilterString
		{
			get
			{
				return filterString;
			}
			set
			{
				filterString = value;
				SelectCountryItem[] componentsInChildren = scrollRect.content.GetComponentsInChildren<SelectCountryItem>(true);
				SelectCountryItem[] array = componentsInChildren;
				foreach (SelectCountryItem selectCountryItem in array)
				{
					if (string.IsNullOrEmpty(value))
					{
						selectCountryItem.gameObject.SetActive(true);
					}
					else
					{
						selectCountryItem.gameObject.SetActive(selectCountryItem.CountryName.ToLower().Contains(filterString.ToLower()));
					}
				}
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			searchInput.ActivateInputField();
			searchInput.scrollSensitivity = 0f;
			searchInput.onValueChanged.AddListener(OnSearchingInputValueChanged);
		}

		public void Init(List<KeyValuePair<string, string>> countries)
		{
			Clean();
			foreach (KeyValuePair<string, string> country2 in countries)
			{
				CreateItem(country2);
			}
			searchInput.text = string.Empty;
			FilterString = string.Empty;
		}

		public void Select(string code)
		{
			SelectCountryItem[] componentsInChildren = GetComponentsInChildren<SelectCountryItem>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (componentsInChildren[i].CountryCode == code)
				{
					componentsInChildren[i].GetComponent<Toggle>().isOn = true;
					VerticalLayoutGroup component = scrollRect.content.GetComponent<VerticalLayoutGroup>();
					LayoutElement component2 = itemPrefab.GetComponent<LayoutElement>();
					float y = (float)i * component2.preferredHeight + (float)i * component.spacing - scrollRect.viewport.rect.height / 2.2f;
					Vector3 targetScrollPotision = new Vector2(scrollRect.content.anchoredPosition.x, y);
					StartCoroutine(ScrollToSelection(targetScrollPotision));
					break;
				}
			}
		}

		private IEnumerator ScrollToSelection(Vector3 targetScrollPotision)
		{
			scrollRect.inertia = false;
			yield return new WaitForEndOfFrame();
			if (targetScrollPotision.y > scrollRect.content.rect.height - scrollRect.viewport.rect.height)
			{
				targetScrollPotision.y = scrollRect.content.rect.height - scrollRect.viewport.rect.height;
			}
			scrollRect.content.anchoredPosition = targetScrollPotision;
			yield return new WaitForEndOfFrame();
			scrollRect.inertia = true;
		}

		private void CreateItem(KeyValuePair<string, string> pair)
		{
			SelectCountryItem selectCountryItem = UnityEngine.Object.Instantiate(itemPrefab);
			selectCountryItem.transform.SetParent(scrollRect.content, false);
			selectCountryItem.Init(pair);
			selectCountryItem.gameObject.SetActive(true);
			selectCountryItem.countrySelected = (CountrySelected)Delegate.Combine(selectCountryItem.countrySelected, new CountrySelected(CountrySelected));
		}

		private void CountrySelected(KeyValuePair<string, string> country)
		{
			this.country = country;
		}

		private void Clean()
		{
			scrollRect.content.DestroyChildren();
		}

		private void OnDisable()
		{
			Clean();
			searchInput.onValueChanged.RemoveListener(OnSearchingInputValueChanged);
		}

		private void OnSearchingInputValueChanged(string value)
		{
			FilterString = value;
		}
	}
}
