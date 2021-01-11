using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	public class TankCollisionComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private bool hasCollision;

		public bool HasCollision
		{
			get
			{
				return hasCollision;
			}
		}

		public Collision Collision
		{
			get;
			private set;
		}

		private void OnCollisionEnter(Collision collision)
		{
			hasCollision = true;
			Collision = collision;
		}

		private void OnCollisionExit(Collision collision)
		{
			hasCollision = false;
			Collision = null;
		}
	}
}
