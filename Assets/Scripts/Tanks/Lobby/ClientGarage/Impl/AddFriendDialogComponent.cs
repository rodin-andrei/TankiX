using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class AddFriendDialogComponent : ConfirmDialogComponent
	{
		[SerializeField]
		private TMP_InputField inputField;

		protected override void OnEnable()
		{
			base.OnEnable();
			ShowInput();
		}

		private void ShowInput()
		{
			inputField.ActivateInputField();
		}
	}
}
