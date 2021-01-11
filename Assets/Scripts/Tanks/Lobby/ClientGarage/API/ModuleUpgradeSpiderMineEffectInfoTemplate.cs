using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Lobby.ClientGarage.API
{
	[SerialVersionUID(636364878050935974L)]
	public interface ModuleUpgradeSpiderMineEffectInfoTemplate : ModuleUpgradeCommonMineEffectInfoTemplate, ModuleUpgradeInfoTemplate, Template
	{
		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleEffectAccelerationPropertyComponent moduleEffectAccelerationProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleSpiderMineEffectChasingEnergyDrainRatePropertyComponent moduleSpiderMineEffectChasingEnergyDrainRateProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleSpiderMineEffectEnergyPropertyComponent moduleSpiderMineEffectEnergyProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleSpiderMineEffectIdleEnergyDrainRatePropertyComponent moduleSpiderMineEffectIdleEnergyDrainRateProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleEffectSpeedPropertyComponent moduleEffectSpeedProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleEffectTargetingDistancePropertyComponent moduleEffectTargetingDistanceProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleEffectTargetingPeriodPropertyComponent moduleEffectTargetingPeriodProperty();
	}
}
