using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class BulletShellTailBehavior : MonoBehaviour
	{
		[SerializeField]
		private int yFrames;
		[SerializeField]
		private int fps;
		[SerializeField]
		private LineRenderer lineRenderer;
		[SerializeField]
		private float zFrom;
		[SerializeField]
		private float zTo;
		[SerializeField]
		private float zTime;
	}
}
