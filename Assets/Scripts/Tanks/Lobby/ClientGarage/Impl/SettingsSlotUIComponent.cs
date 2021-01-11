using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class SettingsSlotUIComponent : MonoBehaviour
	{
		[SerializeField]
		private ImageSkin moduleIconImageSkin;

		[SerializeField]
		private GameObject moduleIsPresent;

		[SerializeField]
		private GameObject whiteBack;

		[SerializeField]
		private Image moduleIconImage;

		[SerializeField]
		private Color activeModuleIconColor;

		[SerializeField]
		private Color inactiveModuleIconColor;

		public void SetIcon(string udid, bool moduleActive = true)
		{
			whiteBack.SetActive(string.IsNullOrEmpty(udid));
			moduleIsPresent.SetActive(!string.IsNullOrEmpty(udid));
			moduleIconImageSkin.SpriteUid = udid;
			moduleIconImage.color = ((!moduleActive) ? inactiveModuleIconColor : activeModuleIconColor);
		}
	}
}
