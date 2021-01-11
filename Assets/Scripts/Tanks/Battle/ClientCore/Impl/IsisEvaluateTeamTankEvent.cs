using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class IsisEvaluateTeamTankEvent : Event
	{
		public TargetData TargetData
		{
			get;
			set;
		}

		public long ShooterTeamKey
		{
			get;
			set;
		}

		public IsisEvaluateTeamTankEvent()
		{
		}

		public IsisEvaluateTeamTankEvent(TargetData targetData, long shooterTeamKey)
		{
			TargetData = targetData;
			ShooterTeamKey = shooterTeamKey;
		}
	}
}
