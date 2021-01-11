using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Lobby.ClientGarage.API
{
	[SerialVersionUID(636364875302316714L)]
	public interface ModuleUpgradeCommonMineEffectInfoTemplate : ModuleUpgradeInfoTemplate, Template
	{
		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleEffectMinDamagePropertyComponent moduleEffectMinDamageProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleEffectMaxDamagePropertyComponent moduleEffectMaxDamageProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleMineEffectImpactPropertyComponent moduleMineEffectImpactProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleMineEffectHideRangePropertyComponent moduleMineEffectHideRangeProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleMineEffectBeginHideDistancePropertyComponent moduleMineEffectBeginHideDistanceProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleEffectActivationTimePropertyComponent moduleEffectActivationTimeProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleMineEffectSplashDamageMaxRadiusPropertyComponent moduleMineEffectSplashDamageMaxRadiusProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleMineEffectSplashDamageMinPercentPropertyComponent moduleMineEffectSplashDamageMinPercentProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleMineEffectSplashDamageMinRadiusPropertyComponent moduleMineEffectSplashDamageMinRadiusProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleLimitBundleEffectCountPropertyComponent moduleLimitBundleEffectCountProperty();
	}
}
