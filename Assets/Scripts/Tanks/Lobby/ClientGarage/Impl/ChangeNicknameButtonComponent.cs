using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ChangeNicknameButtonComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI price;
		[SerializeField]
		private PaletteColorField notEnoughColor;
	}
}
