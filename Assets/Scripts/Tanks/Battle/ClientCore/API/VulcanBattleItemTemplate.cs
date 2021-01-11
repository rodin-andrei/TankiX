using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using Tanks.Battle.ClientCore.Impl;

namespace Tanks.Battle.ClientCore.API
{
	[SerialVersionUID(-3936735916503799349L)]
	public interface VulcanBattleItemTemplate : WeaponTemplate, Template
	{
		VulcanComponent vulcan();

		[PersistentConfig("", false)]
		VerticalSectorsTargetingComponent verticalSectorsTargeting();

		[PersistentConfig("", false)]
		VulcanWeaponComponent vulcanWeapon();

		KickbackComponent kickback();

		ImpactComponent impact();

		[AutoAdded]
		VulcanEnergyBarComponent vulcanEnergyBar();

		[PersistentConfig("", false)]
		DistanceAndAngleTargetEvaluatorComponent distanceAndAngleTargetEvaluator();

		[AutoAdded]
		VulcanWeaponStateComponent vulcanWeaponState();

		[AutoAdded]
		[PersistentConfig("reticle", false)]
		ReticleTemplateComponent reticleTemplate();
	}
}
