using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class GarageListItemContentPreviewComponent : BehaviourComponent
	{
		[SerializeField]
		private ImageSkin skin;

		[SerializeField]
		private Image image;

		[SerializeField]
		private Text count;

		public Image Image
		{
			get
			{
				return image;
			}
		}

		public long Count
		{
			set
			{
				count.text = value.ToString();
				count.gameObject.SetActive(true);
			}
		}

		public void SetImage(string spriteUid)
		{
			skin.SpriteUid = spriteUid;
			image.enabled = true;
			skin.enabled = true;
		}

		public void SetEmptyImage()
		{
			skin.ResetSkin();
			image.enabled = false;
			skin.enabled = false;
		}
	}
}
