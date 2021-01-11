using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	public class SprayEvent : Platform.Kernel.ECS.ClientEntitySystem.API.Event
	{
		public Vector3 Position
		{
			get;
			set;
		}

		public SprayEvent()
		{
		}

		public SprayEvent(Vector3 position)
		{
			Position = position;
		}

		public override string ToString()
		{
			return string.Format("Position: {0}", Position);
		}
	}
}
