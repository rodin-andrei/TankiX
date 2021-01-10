using UnityEngine;
using TMPro;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Battle.ClientBattleSelect.Impl
{
	public class NextLeagueTooltipContent : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI text;
		[SerializeField]
		private ImageSkin leagueIcon;
		[SerializeField]
		private TextMeshProUGUI leagueName;
		[SerializeField]
		private LocalizedField leaguePointsText;
		[SerializeField]
		private LocalizedField leagueNameText;
	}
}
