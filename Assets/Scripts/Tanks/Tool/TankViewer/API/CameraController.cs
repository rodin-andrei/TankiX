using UnityEngine;
using Tanks.Battle.ClientGraphics.API;

namespace Tanks.Tool.TankViewer.API
{
	public class CameraController : MonoBehaviour
	{
		public CameraModeController cameraModeController;
		public TargetCameraController targetCameraController;
		public FreeCameraController freeCameraController;
	}
}
