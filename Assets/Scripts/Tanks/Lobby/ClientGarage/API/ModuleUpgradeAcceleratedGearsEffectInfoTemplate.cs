using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Lobby.ClientGarage.API
{
	[SerialVersionUID(636353692770418059L)]
	public interface ModuleUpgradeAcceleratedGearsEffectInfoTemplate : ModuleUpgradeInfoTemplate, Template
	{
		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleAcceleratedGearsEffectTurretAccelerationPropertyComponent moduleAcceleratedGearsEffectTurretAccelerationProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleAcceleratedGearsEffectTurretSpeedPropertyComponent moduleAcceleratedGearsEffectTurretSpeedProperty();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleAcceleratedGearsEffectHullRotationSpeedPropertyComponent moduleAcceleratedGearsEffectHullRotationSpeedProperty();
	}
}
