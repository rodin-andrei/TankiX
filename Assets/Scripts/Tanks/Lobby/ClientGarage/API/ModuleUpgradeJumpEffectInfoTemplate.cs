using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Lobby.ClientGarage.API
{
	[SerialVersionUID(1538452035606L)]
	public interface ModuleUpgradeJumpEffectInfoTemplate : ModuleUpgradeInfoTemplate, Template
	{
		[AutoAdded]
		[PersistentConfig("", false)]
		JumpImpactForceMultPropertyComponent jumpImpactForceMultProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		JumpImpactWorkingTemperaturePropertyComponent jumpImpactWorkingTemperatureProperty();
	}
}
