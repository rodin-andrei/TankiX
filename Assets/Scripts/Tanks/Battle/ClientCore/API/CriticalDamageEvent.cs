using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	[Shared]
	[SerialVersionUID(-4247034853035810941L)]
	public class CriticalDamageEvent : Platform.Kernel.ECS.ClientEntitySystem.API.Event
	{
		public Entity Target
		{
			get;
			set;
		}

		public Vector3 LocalPosition
		{
			get;
			set;
		}
	}
}
