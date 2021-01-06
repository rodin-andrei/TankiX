using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ShaftAimingLaserBehaviour : MonoBehaviour
	{
		[SerializeField]
		private float fadeInTimeSec;
		[SerializeField]
		private float fadeOutTimeSec;
		[SerializeField]
		private float maxStartAlpha;
		[SerializeField]
		private float texScale;
		[SerializeField]
		private float laserWidth;
		[SerializeField]
		private float laserSourceOffset;
		[SerializeField]
		private float laserBeginLength;
		[SerializeField]
		private float speed1;
		[SerializeField]
		private float speed2;
		[SerializeField]
		private float delta;
	}
}
