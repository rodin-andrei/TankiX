using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class NicknameChangeDialog : ConfirmDialogComponent
	{
		[SerializeField]
		private Button button;
		[SerializeField]
		private TMP_InputField inputField;
	}
}
