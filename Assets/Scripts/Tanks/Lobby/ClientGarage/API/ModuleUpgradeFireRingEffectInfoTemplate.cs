using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using Tanks.Lobby.ClientGarage.API.FireTrap;

namespace Tanks.Lobby.ClientGarage.API
{
	[SerialVersionUID(1542699020893L)]
	public interface ModuleUpgradeFireRingEffectInfoTemplate : ModuleUpgradeInfoTemplate, Template
	{
		[AutoAdded]
		ModuleFireRingEffectPropertyComponent moduleFireRingEffectProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleEffectSplashRadiusPropertyComponent moduleEffectSplashRadiusProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleEffectSplashDamageMinPercentPropertyComponent moduleEffectSplashDamageMinPercentProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleEffectImpactPropertyComponent moduleEffectImpactProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleEffectMinDamagePropertyComponent moduleEffectMinDamageProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleEffectMaxDamagePropertyComponent moduleEffectMaxDamageProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleIcetrapEffectTemperatureDurationPropertyComponent moduleIcetrapEffectTemperatureDurationProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleIcetrapEffectTemperatureDeltaPropertyComponent moduleIcetrapEffectTemperatureDeltaProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleIcetrapEffectTemperatureLimitPropertyComponent moduleIcetrapEffectTemperatureLimitProperty();
	}
}
