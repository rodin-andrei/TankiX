using UnityEngine;
using Tanks.Lobby.ClientControls.API;
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
	}
}
