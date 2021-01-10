using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class PrivacyPolicyDialog : ConfirmDialogComponent
	{
		[SerializeField]
		private LocalizedField fileName;
		[SerializeField]
		private TextMeshProUGUI text;
	}
}
