using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class BattleResultsScreenStatComponent : BehaviourComponent
	{
		[SerializeField]
		private GameObject dmMatchDetails;
		[SerializeField]
		private GameObject teamMatchDetails;
		[SerializeField]
		private TextMeshProUGUI _battleDescription;
	}
}
