using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using System.Collections.Generic;

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
	}
}
