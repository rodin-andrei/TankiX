using UnityEngine;

namespace Tanks.Tool.TankViewer.API
{
	public class DefaultMode : CameraMode
	{
		private Camera camera;

		public DefaultMode(Camera camera)
		{
			this.camera = camera;
		}

		public void SwitchOn()
		{
			camera.gameObject.SetActive(true);
		}

		public void SwithOff()
		{
			camera.gameObject.SetActive(false);
		}
	}
}
