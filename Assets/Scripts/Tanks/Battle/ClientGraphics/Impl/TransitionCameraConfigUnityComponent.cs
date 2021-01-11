using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class TransitionCameraConfigUnityComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private float flyHeight = 1f;

		[SerializeField]
		private float flyTimeSec = 0.55f;

		public float FlyHeight
		{
			get
			{
				return flyHeight;
			}
			set
			{
				flyHeight = value;
			}
		}

		public float FlyTimeSec
		{
			get
			{
				return flyTimeSec;
			}
			set
			{
				flyTimeSec = value;
			}
		}
	}
}
