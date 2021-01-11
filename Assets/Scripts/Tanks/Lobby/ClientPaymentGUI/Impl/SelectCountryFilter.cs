using System;
using System.Collections.Generic;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class SelectCountryFilter : MonoBehaviour
	{
		[SerializeField]
		private FilteredListDataProvider list;

		[SerializeField]
		private InputField inputField;

		private void OnEnable()
		{
			inputField.onValueChanged.AddListener(ApplyFilter);
		}

		private void OnDisable()
		{
			inputField.onValueChanged.RemoveListener(ApplyFilter);
		}

		private void ApplyFilter(string arg0)
		{
			list.ApplyFilter(IsFiltered);
		}

		private bool IsFiltered(object dataProvider)
		{
			KeyValuePair<string, string> keyValuePair = (KeyValuePair<string, string>)dataProvider;
			if (string.IsNullOrEmpty(inputField.text))
			{
				return false;
			}
			return !keyValuePair.Value.StartsWith(inputField.text, StringComparison.CurrentCultureIgnoreCase);
		}
	}
}
