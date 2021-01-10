using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class SlotUI : MonoBehaviour
	{
		[SerializeField]
		private ImageSkin moduleIcon;
		[SerializeField]
		private PaletteColorField exceptionalColor;
		[SerializeField]
		private PaletteColorField epicColor;
		[SerializeField]
		private Image lockImage;
	}
}
