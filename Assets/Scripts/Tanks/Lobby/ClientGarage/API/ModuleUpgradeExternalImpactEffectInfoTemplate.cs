using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Lobby.ClientGarage.API
{
	[SerialVersionUID(1542275711926L)]
	public interface ModuleUpgradeExternalImpactEffectInfoTemplate : ModuleUpgradeInfoTemplate, Template
	{
		[AutoAdded]
		ModuleExternalImpactEffectPropertyComponent moduleExternalImpactEffectProperty();

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
