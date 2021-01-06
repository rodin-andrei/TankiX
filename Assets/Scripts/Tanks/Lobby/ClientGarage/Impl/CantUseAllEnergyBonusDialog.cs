using TMPro;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class CantUseAllEnergyBonusDialog : ConfirmWindowComponent
	{
		[SerializeField]
		private TextMeshProUGUI question;
		[SerializeField]
		private LocalizedField questionText;
	}
}
