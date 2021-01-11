using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Lobby.ClientGarage.API
{
	[SerialVersionUID(636352947010929322L)]
	public interface ModuleUpgradeHealingEffectInfoTemplate : ModuleUpgradeEffectWithDurationTemplate, ModuleUpgradeInfoTemplate, Template
	{
		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleHealingEffectHPPerMSPropertyComponent moduleHealingEffectHPPerMSProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleHealingEffectInstantHPPropertyComponent moduleHealingEffectInstantHPProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleHealingEffectFirstTickMSPropertyComponent moduleHealingEffectFirstTickMsProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleHealingEffectPeriodicTickPropertyComponent moduleHealingEffectPeriodicTickProperty();
	}
}
