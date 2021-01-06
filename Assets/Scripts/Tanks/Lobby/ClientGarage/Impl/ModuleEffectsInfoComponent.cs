using UnityEngine.EventSystems;
using TMPro;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ModuleEffectsInfoComponent : UIBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI effectText;
		[SerializeField]
		private ImageSkin effectIcon;
		[SerializeField]
		private PaletteColorField exceptionalColor;
		[SerializeField]
		private PaletteColorField epicColor;
		[SerializeField]
		private Image staticIcon;
	}
}
