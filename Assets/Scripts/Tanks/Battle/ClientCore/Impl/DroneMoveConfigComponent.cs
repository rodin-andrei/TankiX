using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	[SerialVersionUID(3441234123559L)]
	[Shared]
	public class DroneMoveConfigComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		private Vector3 spawnPosition;

		private Vector3 flyPosition;

		private float rotationSpeed;

		private float moveSpeed;

		private float acceleration;

		public float Acceleration
		{
			get
			{
				return acceleration;
			}
			set
			{
				acceleration = value;
			}
		}

		public Vector3 SpawnPosition
		{
			get
			{
				return spawnPosition;
			}
			set
			{
				spawnPosition = value;
			}
		}

		public Vector3 FlyPosition
		{
			get
			{
				return flyPosition;
			}
			set
			{
				flyPosition = value;
			}
		}

		public float RotationSpeed
		{
			get
			{
				return rotationSpeed;
			}
			set
			{
				rotationSpeed = value;
			}
		}

		public float MoveSpeed
		{
			get
			{
				return moveSpeed;
			}
			set
			{
				moveSpeed = value;
			}
		}
	}
}
