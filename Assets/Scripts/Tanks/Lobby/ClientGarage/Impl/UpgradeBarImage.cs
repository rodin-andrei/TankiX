using UnityEngine.UI;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class UpgradeBarImage : MaskableGraphic
	{
		[SerializeField]
		private float spacing;
		[SerializeField]
		private int segmentsCount;
		[SerializeField]
		private Sprite sprite;
		[SerializeField]
		private PaletteColorField filledColor;
		[SerializeField]
		private PaletteColorField upgradeColor;
		[SerializeField]
		private PaletteColorField backgroundColor;
		[SerializeField]
		private PaletteColorField strokeColor;
	}
}
