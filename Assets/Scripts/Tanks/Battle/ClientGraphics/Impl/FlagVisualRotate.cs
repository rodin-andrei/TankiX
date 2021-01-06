using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class FlagVisualRotate : MonoBehaviour
	{
		public GameObject flag;
		public Transform tank;
		public float timerUpsideDown;
		public float scale;
		public float origin;
		public float distanceForRotateFlag;
		public Component sprite;
		public Sprite3D spriteComponent;
	}
}
