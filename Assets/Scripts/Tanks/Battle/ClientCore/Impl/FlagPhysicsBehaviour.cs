using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class FlagPhysicsBehaviour : TriggerBehaviour<TankFlagCollisionEvent>
	{
		private void OnTriggerEnter(Collider other)
		{
			SendEventByCollision(other);
		}

		private void OnTriggerExit(Collider other)
		{
			SendEventByCollision(other);
		}
	}
}
