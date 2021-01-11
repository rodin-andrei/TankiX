using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class BulletBuildEvent : Platform.Kernel.ECS.ClientEntitySystem.API.Event
	{
		public Vector3 Direction
		{
			get;
			set;
		}

		public BulletBuildEvent()
		{
		}

		public BulletBuildEvent(Vector3 direction)
		{
			Direction = direction;
		}
	}
}
