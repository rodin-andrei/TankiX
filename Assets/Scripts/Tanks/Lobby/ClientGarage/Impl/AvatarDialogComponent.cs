using UnityEngine.UI;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class AvatarDialogComponent : ConfirmDialogComponent
	{
		[SerializeField]
		private Button cancelButton;
		[SerializeField]
		private Button closeButton;
	}
}
