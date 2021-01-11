using Tanks.Battle.ClientBattleSelect.Impl;
using Tanks.Battle.ClientCore.API;
using TMPro;
using UnityEngine;

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

		public void Set(UserResult mvp, BattleResultForClient battleResultForClient)
		{
			assists.SetActive(battleResultForClient.BattleMode != BattleMode.DM);
			killsCount.SetText(mvp.Kills.ToString());
			assistsCount.SetText(mvp.KillAssists.ToString());
			deathsCount.SetText(mvp.Deaths.ToString());
		}
	}
}
