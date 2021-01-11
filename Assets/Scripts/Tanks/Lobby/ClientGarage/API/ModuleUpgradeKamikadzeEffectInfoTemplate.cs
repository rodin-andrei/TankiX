using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Lobby.ClientGarage.API
{
	[SerialVersionUID(1554360394829L)]
	public interface ModuleUpgradeKamikadzeEffectInfoTemplate : ModuleUpgradeInfoTemplate, Template
	{
		[AutoAdded]
		ModuleKamikadzeEffectPropertyComponent moduleKamikadzeEFfectProperty();

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
	}
}
