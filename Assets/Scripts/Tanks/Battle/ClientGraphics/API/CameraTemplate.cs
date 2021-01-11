using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Battle.ClientGraphics.API
{
	[SerialVersionUID(1453364101465L)]
	public interface CameraTemplate : Template
	{
		[AutoAdded]
		[PersistentConfig("", false)]
		CameraOffsetConfigComponent cameraOffsetConfig();

		[AutoAdded]
		[PersistentConfig("", false)]
		TankCameraShakerConfigOnDeathComponent tankCameraShakerConfigOnDeath();

		[AutoAdded]
		[PersistentConfig("", false)]
		TankFallingCameraShakerConfigComponent tankFallingCameraShakerConfig();
	}
}
