using Tanks.Battle.ClientCore.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class TankCollisionDetector : MonoBehaviour
	{
		public TankCollisionDetectionComponent tankCollisionComponent;

		public int UpdatesCout
		{
			get;
			set;
		}

		public bool CanBeActivated
		{
			get;
			set;
		}

		private void OnEnable()
		{
			UpdatesCout = 0;
		}

		private void FixedUpdate()
		{
			if (UpdatesCout == 0)
			{
				CanBeActivated = true;
			}
			UpdatesCout++;
		}

		private void OnTriggerEnter(Collider other)
		{
			CheckCollisionsWithOtherTanks(other);
		}

		private void OnTriggerStay(Collider other)
		{
			CheckCollisionsWithOtherTanks(other);
		}

		private void CheckCollisionsWithOtherTanks(Collider other)
		{
			if (other.gameObject.layer == Layers.REMOTE_TANK_BOUNDS)
			{
				CanBeActivated = false;
			}
		}
	}
}
