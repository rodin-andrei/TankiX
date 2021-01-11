using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ShaftAimingRendererQueueMapComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Dictionary<Material, int> QueueMap
		{
			get;
			set;
		}

		public ShaftAimingRendererQueueMapComponent()
		{
			QueueMap = new Dictionary<Material, int>();
		}
	}
}
