using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	public abstract class BulletHitEvent : Platform.Kernel.ECS.ClientEntitySystem.API.Event
	{
		public Vector3 Position
		{
			get;
			set;
		}
	}
}
