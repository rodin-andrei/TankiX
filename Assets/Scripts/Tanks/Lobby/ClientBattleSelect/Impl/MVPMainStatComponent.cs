using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class MVPMainStatComponent : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI killsCount;
		[SerializeField]
		private TextMeshProUGUI assistsCount;
		[SerializeField]
		private TextMeshProUGUI deathsCount;
		[SerializeField]
		private GameObject kills;
		[SerializeField]
		private GameObject assists;
		[SerializeField]
		private GameObject deaths;
	}
}
