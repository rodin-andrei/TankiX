using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ExplosionEvent : Platform.Kernel.ECS.ClientEntitySystem.API.Event
	{
		public HitTarget Target;

		public GameObject Asset
		{
			get;
			set;
		}

		public Vector3 ExplosionOffset
		{
			get;
			set;
		}

		public Vector3 HitDirection
		{
			get;
			set;
		}

		public float Duration
		{
			get;
			set;
		}
	}
}
