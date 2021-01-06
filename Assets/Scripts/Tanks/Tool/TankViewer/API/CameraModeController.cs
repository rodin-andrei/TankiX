using UnityEngine;
using System.Collections.Generic;

namespace Tanks.Tool.TankViewer.API
{
	public class CameraModeController : MonoBehaviour
	{
		public Camera mainCamera;
		public Camera solidBackCamera;
		public List<Color> backColors;
		public Camera maskCamera;
		public GameObject plane;
	}
}
