using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using Tanks.Battle.ClientCore.Impl;

namespace Tanks.Battle.ClientCore.API
{
	[SerialVersionUID(-2537616944465628484L)]
	public interface ShaftBattleItemTemplate : WeaponTemplate, Template
	{
		ShaftComponent shaft();

		DirectionEvaluatorComponent directionEvaluator();

		[PersistentConfig("", false)]
		DistanceAndAngleTargetEvaluatorComponent distanceAndAngleTargetEvaluator();

		ShaftStateControllerComponent shaftStateController();

		[PersistentConfig("", false)]
		ShaftStateConfigComponent shaftStateConfig();

		[PersistentConfig("", false)]
		VerticalSectorsTargetingComponent verticalSectorsTargeting();

		[AutoAdded]
		EnergyBarComponent energyBar();

		KickbackComponent kickback();

		ImpactComponent impact();

		ShaftAimingImpactComponent shaftAimingImpact();

		ShaftEnergyComponent shaftEnergy();

		[AutoAdded]
		[PersistentConfig("reticle", false)]
		ReticleTemplateComponent reticleTemplate();
	}
}
