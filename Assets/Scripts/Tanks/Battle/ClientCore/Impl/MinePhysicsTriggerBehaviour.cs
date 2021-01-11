using Platform.Library.ClientDataStructures.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class MinePhysicsTriggerBehaviour : TriggerBehaviour<TriggerEnterEvent>
	{
		private void Start()
		{
			GetComponentsInChildren<Collider>(true).ForEach(delegate(Collider c)
			{
				c.enabled = true;
			});
		}

		private void OnTriggerEnter(Collider other)
		{
			SendEventByCollision(other);
		}
	}
}
