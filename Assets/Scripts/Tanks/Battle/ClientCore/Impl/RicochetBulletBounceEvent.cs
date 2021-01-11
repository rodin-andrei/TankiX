using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class RicochetBulletBounceEvent : Platform.Kernel.ECS.ClientEntitySystem.API.Event
	{
		public Vector3 WorldSpaceBouncePosition
		{
			get;
			set;
		}

		public RicochetBulletBounceEvent()
		{
		}

		public RicochetBulletBounceEvent(Vector3 worldSpaceBouncePosition)
		{
			WorldSpaceBouncePosition = worldSpaceBouncePosition;
		}
	}
}
