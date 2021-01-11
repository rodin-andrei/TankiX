using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class FollowCameraComponent : Component
	{
		public float verticalCameraSpeed = 0.5f;

		public float rollReturnSpeedDegPerSec = 60f;

		public CameraData cameraData;
	}
}
