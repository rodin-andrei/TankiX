using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class StarterPackButtonComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI text;
		[SerializeField]
		private ImageSkin buttonBG;
	}
}
