using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class SelectCountryItem : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI countryName;

		public CountrySelected countrySelected;

		private KeyValuePair<string, string> country;

		public string CountryName
		{
			get
			{
				return country.Value;
			}
			set
			{
				countryName.text = value;
			}
		}

		public string CountryCode
		{
			get
			{
				return country.Key;
			}
		}

		private void Awake()
		{
			GetComponent<Toggle>().onValueChanged.AddListener(ToggleValueChanged);
		}

		public void Init(KeyValuePair<string, string> country)
		{
			this.country = country;
			CountryName = country.Value;
		}

		private void ToggleValueChanged(bool value)
		{
			if (value && countrySelected != null)
			{
				countrySelected(country);
			}
		}

		private void OnDestroy()
		{
			countrySelected = null;
		}
	}
}
