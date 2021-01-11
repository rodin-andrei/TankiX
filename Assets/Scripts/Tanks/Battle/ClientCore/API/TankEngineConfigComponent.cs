using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	public class TankEngineConfigComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		[Range(0f, 1f)]
		private float minEngineMovingBorder;

		[SerializeField]
		[Range(0f, 1f)]
		private float maxEngineMovingBorder;

		[SerializeField]
		[Range(0f, 1f)]
		private float engineTurningBorder;

		[SerializeField]
		private float engineCollisionIntervalSec = 0.5f;

		public float EngineCollisionIntervalSec
		{
			get
			{
				return engineCollisionIntervalSec;
			}
			set
			{
				engineCollisionIntervalSec = value;
			}
		}

		public float MinEngineMovingBorder
		{
			get
			{
				return minEngineMovingBorder;
			}
			set
			{
				minEngineMovingBorder = value;
			}
		}

		public float MaxEngineMovingBorder
		{
			get
			{
				return maxEngineMovingBorder;
			}
			set
			{
				maxEngineMovingBorder = value;
			}
		}

		public float EngineTurningBorder
		{
			get
			{
				return engineTurningBorder;
			}
			set
			{
				engineTurningBorder = value;
			}
		}
	}
}
