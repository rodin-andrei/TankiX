using TMPro;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class EmailConfirmDialog : ConfirmDialogComponent
	{
		[SerializeField]
		private TextMeshProUGUI confirmationHintLabel;
		[SerializeField]
		private LocalizedField confirmationHint;
		[SerializeField]
		private PaletteColorField emailColor;
	}
}
