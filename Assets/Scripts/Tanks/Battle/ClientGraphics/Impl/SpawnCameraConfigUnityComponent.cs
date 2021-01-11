using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class SpawnCameraConfigUnityComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private float flyHeight = 30f;

		[SerializeField]
		private float flyTimeSec = 2f;

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
