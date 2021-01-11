using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	[Shared]
	[SerialVersionUID(1494934093730L)]
	public class DamageInfoEvent : Platform.Kernel.ECS.ClientEntitySystem.API.Event
	{
		public float Damage
		{
			get;
			set;
		}

		public Vector3 HitPoint
		{
			get;
			set;
		}

		public bool BackHit
		{
			get;
			set;
		}

		public bool HealHit
		{
			get;
			set;
		}
	}
}
