using UnityEngine;
using Tanks.Battle.ClientBattleSelect.Impl;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class MVPTankInfoComponent : MonoBehaviour
	{
		[SerializeField]
		private TankPartInfoComponent hull;
		[SerializeField]
		private TankPartInfoComponent turret;
	}
}
