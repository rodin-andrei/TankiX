using UnityEngine;

namespace Tanks.Tool.TankViewer.API
{
	public class SolidBackMode : CameraMode
	{
		private Camera solidBackgroundCamera;

		private Color backColor;

		public SolidBackMode(Camera solidBackgroundCamera, Color backColor)
		{
			this.solidBackgroundCamera = solidBackgroundCamera;
			this.backColor = backColor;
		}

		public void SwitchOn()
		{
			solidBackgroundCamera.backgroundColor = backColor;
			Debug.Log(solidBackgroundCamera.backgroundColor);
			solidBackgroundCamera.gameObject.SetActive(true);
		}

		public void SwithOff()
		{
			solidBackgroundCamera.gameObject.SetActive(false);
		}
	}
}
