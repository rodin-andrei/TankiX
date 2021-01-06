using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class LeagueTitleUIComponent : BehaviourComponent
	{
		[SerializeField]
		private new TextMeshProUGUI name;
		[SerializeField]
		private ImageSkin icon;
	}
}
