using Platform.Library.ClientUnityIntegration.API;
using UnityEngine.UI;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class BattleSelectScreenLocalizationComponent : BehaviourComponent
	{
		[SerializeField]
		private Text playButton;
		[SerializeField]
		private Text archivedBattle;
		[SerializeField]
		private Text archivedBattleTeam;
		[SerializeField]
		private Text playRedButton;
		[SerializeField]
		private Text playBlueButton;
		[SerializeField]
		private Text watchButton;
		[SerializeField]
		private Text redTeamName;
		[SerializeField]
		private Text blueTeamName;
	}
}
