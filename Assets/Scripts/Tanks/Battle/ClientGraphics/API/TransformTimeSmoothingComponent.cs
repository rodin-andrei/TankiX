using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public class TransformTimeSmoothingComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public bool UseCorrectionByFrameLeader
		{
			get;
			set;
		}

		public Transform Transform
		{
			get;
			set;
		}

		public TransformTimeSmoothingComponent(Transform transform)
		{
			Transform = transform;
		}

		public TransformTimeSmoothingComponent()
		{
		}
	}
}
