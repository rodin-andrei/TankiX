using UnityEngine;
using TMPro;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class SelectedItemUI : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI itemName;
		[SerializeField]
		private TextMeshProUGUI feature;
		[SerializeField]
		private MainVisualPropertyUI[] props;
		[SerializeField]
		private AnimatedNumber mastery;
		[SerializeField]
		private TextMeshProUGUI currentSkin;
		[SerializeField]
		private UpgradeStars upgradeStars;
		[SerializeField]
		private LocalizedField currentSkinLocalizedField;
	}
}
