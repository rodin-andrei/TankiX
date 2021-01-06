using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public class CameraShakeInstance
	{
		public float magnitude;
		public float roughness;
		public Vector3 positionInfluence;
		public Vector3 rotationInfluence;
		public bool deleteOnInactive;
	}
}
