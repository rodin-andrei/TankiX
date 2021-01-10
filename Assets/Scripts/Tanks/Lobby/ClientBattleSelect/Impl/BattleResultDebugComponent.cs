using UnityEngine.EventSystems;
using Tanks.Battle.ClientCore.API;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class BattleResultDebugComponent : UIBehaviour
	{
		public double Reputation;
		public double ReputationDelta;
		public int Energy;
		public int EnergyDelta;
		public int CrystalsForExtraEnergy;
		public EnergySource MaxEnergySource;
		public int RankExp;
		public int RankExpDelta;
		public int WeaponExp;
		public int WeaponInitExp;
		public int WeaponFinalExp;
		public int TankExp;
		public int TankInitExp;
		public int TankFinalExp;
		public int ItemsExpDelta;
		public int ContainerScore;
		public float ContainerScoreMultiplier;
		public int ContainerScoreDelta;
		public int ContainerScoreLimit;
		public long Reward;
		public long HullId;
		public long WeaponId;
		public long HullSkinId;
		public long WeaponSkinId;
	}
}
