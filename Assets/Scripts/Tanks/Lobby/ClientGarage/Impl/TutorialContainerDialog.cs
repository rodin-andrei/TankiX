using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;

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

		public string Message
		{
			set
			{
				message.text = value;
			}
		}

		public string ConatinerImageUID
		{
			set
			{
				containerImage.SpriteUid = value;
			}
		}

		public int ChestCount
		{
			set
			{
				chestCountText.text = "x" + value;
				chestCountText.gameObject.SetActive(value > 0);
			}
		}
	}
}
