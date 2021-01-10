using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.API
{
	public class ScoreTablePingIndicatorComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI pingCount;
	}
}
