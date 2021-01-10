using TMPro;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class CraftModuleConfirmWindowComponent : ConfirmWindowComponent
	{
		[SerializeField]
		protected TextMeshProUGUI additionalText;
		[SerializeField]
		private LocalizedField module;
		[SerializeField]
		private LocalizedField craftFor;
		[SerializeField]
		private LocalizedField decline;
		[SerializeField]
		private LocalizedField upgradeFor;
		[SerializeField]
		private LocalizedField buyBlueprints;
		[SerializeField]
		private Color greenColor;
		[SerializeField]
		private Color whiteColor;
		[SerializeField]
		private Image highlight;
		[SerializeField]
		private Image fill;
		[SerializeField]
		protected ImageSkin icon;
	}
}
