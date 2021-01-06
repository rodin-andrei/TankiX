using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class TutorialContainerDialog : ConfirmDialogComponent
	{
		[SerializeField]
		private ImageSkin containerImage;
		[SerializeField]
		private TextMeshProUGUI message;
		[SerializeField]
		private TextMeshProUGUI chestCountText;
	}
}
