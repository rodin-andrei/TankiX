using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Lobby.ClientGarage.API
{
	[SerialVersionUID(635453745672535457L)]
	public interface ModuleUpgradeDroneEffectInfoTemplate : ModuleUpgradeEffectWithDurationTemplate, ModuleUpgradeInfoTemplate, Template
	{
		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleEffectTargetingDistancePropertyComponent moduleEffectTargetingDistanceProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleEffectTargetingPeriodPropertyComponent moduleEffectTargetingPeriodProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleEffectMinDamagePropertyComponent moduleEffectMinDamageProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleEffectMaxDamagePropertyComponent moduleEffectMaxDamageProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleEffectActivationTimePropertyComponent moduleEffectActivationTimeProperty();
	}
}
