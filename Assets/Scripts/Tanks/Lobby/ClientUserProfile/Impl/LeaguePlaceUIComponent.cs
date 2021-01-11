using System.Collections.Generic;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class LeaguePlaceUIComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI placeText;

		[SerializeField]
		private LocalizedField placeLocalizedField;

		[SerializeField]
		private List<GameObject> elements;

		public void SetPlace(int place)
		{
			placeText.text = placeLocalizedField.Value + "\n" + place;
			Show();
		}

		public void Hide()
		{
			SetElementsVisibility(false);
		}

		private void Show()
		{
			SetElementsVisibility(true);
		}

		private void SetElementsVisibility(bool visibility)
		{
			elements.ForEach(delegate(GameObject element)
			{
				element.SetActive(visibility);
			});
		}
	}
}
