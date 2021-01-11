using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientHangar.Impl
{
	public class HangarCameraRotateEvent : Event
	{
		public float Angle
		{
			get;
			set;
		}

		public HangarCameraRotateEvent()
		{
		}

		public HangarCameraRotateEvent(float angle)
		{
			Angle = angle;
		}
	}
}
