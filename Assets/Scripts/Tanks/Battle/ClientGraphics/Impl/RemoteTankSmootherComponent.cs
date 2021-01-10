using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class RemoteTankSmootherComponent
	{
		public float smoothingCoeff;
		public Vector3 prevVisualPosition;
		public Quaternion prevVisualRotation;
	}
}
