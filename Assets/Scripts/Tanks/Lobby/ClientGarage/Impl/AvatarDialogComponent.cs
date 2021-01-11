using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class AvatarDialogComponent : ConfirmDialogComponent
	{
		[SerializeField]
		private Button cancelButton;

		[SerializeField]
		private Button closeButton;

		private void Awake()
		{
			cancelButton.onClick.AddListener(Hide);
			closeButton.onClick.AddListener(Hide);
		}
	}
}
