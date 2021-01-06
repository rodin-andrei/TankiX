using UnityEngine;
using TMPro;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ModuleTooltipContent : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI title;
		[SerializeField]
		private TextMeshProUGUI description;
		[SerializeField]
		private TextMeshProUGUI upgradeLevel;
		[SerializeField]
		private LocalizedField upgradeLevelLocalization;
		[SerializeField]
		private TextMeshProUGUI currentLevel;
		[SerializeField]
		private TextMeshProUGUI nextLevel;
	}
}
