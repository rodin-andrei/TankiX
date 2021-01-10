using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class OpenSelectCountryButtonComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI buttonTitle;
		[SerializeField]
		private LocalizedField country;
	}
}
