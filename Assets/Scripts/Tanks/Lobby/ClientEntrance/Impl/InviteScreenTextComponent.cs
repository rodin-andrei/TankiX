using Tanks.Lobby.ClientNavigation.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientEntrance.Impl
{
	public class InviteScreenTextComponent : LocalizedScreenComponent
	{
		[SerializeField]
		private TextMeshProUGUI inputHint;
		[SerializeField]
		private TextMeshProUGUI continueButton;
	}
}
