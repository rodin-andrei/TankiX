using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class ProgressPartUI : MonoBehaviour
	{
		[SerializeField]
		private ExperienceResultUI experienceResult;
		[SerializeField]
		private EquipmentResultUI turretResult;
		[SerializeField]
		private EquipmentResultUI hullResult;
		[SerializeField]
		private GameObject progressResult;
		[SerializeField]
		private GameObject energyResult;
		[SerializeField]
		private GameObject leagueResult;
		[SerializeField]
		private GameObject containerResult;
	}
}
