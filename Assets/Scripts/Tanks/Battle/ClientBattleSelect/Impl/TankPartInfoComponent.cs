using UnityEngine;
using Tanks.Lobby.ClientGarage.Impl;
using TMPro;
using Tanks.Lobby.ClientGarage.API;

namespace Tanks.Battle.ClientBattleSelect.Impl
{
	public class TankPartInfoComponent : MonoBehaviour
	{
		[SerializeField]
		private UpgradeStars stars;
		[SerializeField]
		private TextMeshProUGUI title;
		[SerializeField]
		private TextMeshProUGUI icon;
		[SerializeField]
		private TextMeshProUGUI mainValue;
		[SerializeField]
		private TextMeshProUGUI additionalValue;
		[SerializeField]
		private TankPartModuleType tankPartType;
	}
}
