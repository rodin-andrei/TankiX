using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class BonusPhysicsBehaviour : TriggerBehaviour<TriggerEnterEvent>
	{
		private void OnTriggerEnter(Collider other)
		{
			SendEventByCollision(other);
		}
	}
}
