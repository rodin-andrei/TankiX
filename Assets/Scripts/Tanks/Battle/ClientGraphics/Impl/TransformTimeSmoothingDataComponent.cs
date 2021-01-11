using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class TransformTimeSmoothingDataComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Vector3 LastPosition
		{
			get;
			set;
		}

		public Quaternion LastRotation
		{
			get;
			set;
		}

		public float LerpFactor
		{
			get;
			set;
		}

		public float LastRotationDeltaAngle
		{
			get;
			set;
		}
	}
}
