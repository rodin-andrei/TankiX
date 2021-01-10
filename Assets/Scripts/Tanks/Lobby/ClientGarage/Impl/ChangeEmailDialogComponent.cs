using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ChangeEmailDialogComponent : ConfirmDialogComponent
	{
		[SerializeField]
		private GameObject input;
		[SerializeField]
		private GameObject confirm;
		[SerializeField]
		private Button button;
		[SerializeField]
		private TextMeshProUGUI hintLabel;
		[SerializeField]
		private TextMeshProUGUI confirmationHintLabel;
		[SerializeField]
		private LocalizedField hint;
		[SerializeField]
		private LocalizedField confirmationHint;
		[SerializeField]
		private PaletteColorField emailColor;
		[SerializeField]
		private TMP_InputField inputField;
	}
}
