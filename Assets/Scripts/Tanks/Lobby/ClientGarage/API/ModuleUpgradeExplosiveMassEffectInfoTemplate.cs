using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Lobby.ClientGarage.API
{
	[SerialVersionUID(1543484139511L)]
	public interface ModuleUpgradeExplosiveMassEffectInfoTemplate : ModuleUpgradeInfoTemplate, Template
	{
		[AutoAdded]
		ModuleExplosiveMassEffectPropertyComponent moduleExplosiveMassEffectProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleEffectMaxDamagePropertyComponent moduleEffectMaxDamageProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleEffectMinDamagePropertyComponent moduleEffectMinDamageProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleEffectTargetingDistancePropertyComponent moduleEffectTargetingDistanceProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleEffectActivationTimePropertyComponent moduleEffectActivationTimeProperty();
	}
}
