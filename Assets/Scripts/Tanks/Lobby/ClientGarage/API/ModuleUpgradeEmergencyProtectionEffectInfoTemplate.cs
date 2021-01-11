using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Lobby.ClientGarage.API
{
	[SerialVersionUID(636362277898499977L)]
	public interface ModuleUpgradeEmergencyProtectionEffectInfoTemplate : ModuleUpgradeInfoTemplate, Template
	{
		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleEmergencyProtectionEffectHolyshieldDurationPropertyComponent moduleEmergencyProtectionEffectHolyshieldDurationProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleEmergencyProtectionEffectFixedHPPropertyComponent moduleEmergencyProtectionEffectFixedHPProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleEmergencyProtectionEffectAdditiveHPFactorPropertyComponent moduleEmergencyProtectionEffectAdditiveHPFactorProperty();
	}
}
