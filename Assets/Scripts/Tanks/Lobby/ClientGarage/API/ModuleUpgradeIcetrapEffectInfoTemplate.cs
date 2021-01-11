using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Lobby.ClientGarage.API
{
	[SerialVersionUID(636384699493258494L)]
	public interface ModuleUpgradeIcetrapEffectInfoTemplate : ModuleUpgradeMineEffectInfoTemplate, ModuleUpgradeCommonMineEffectInfoTemplate, ModuleUpgradeInfoTemplate, Template
	{
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
