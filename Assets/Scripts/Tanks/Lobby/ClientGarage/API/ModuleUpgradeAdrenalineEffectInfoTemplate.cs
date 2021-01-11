using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Lobby.ClientGarage.API
{
	[SerialVersionUID(636365877967485486L)]
	public interface ModuleUpgradeAdrenalineEffectInfoTemplate : ModuleUpgradeInfoTemplate, Template
	{
		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleAdrenalineEffectMaxHPPercentWorkingPropertyComponent moduleAdrenalineEffectMaxHPPercentWorkingProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleAdrenalineEffectCooldownSpeedCoeffPropertyComponent moduleAdrenalineEffectCooldownSpeedCoeffProperty();
	}
}
