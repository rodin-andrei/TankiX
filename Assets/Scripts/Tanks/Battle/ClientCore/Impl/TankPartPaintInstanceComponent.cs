using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class TankPartPaintInstanceComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public GameObject PaintInstance
		{
			get;
			set;
		}

		public TankPartPaintInstanceComponent()
		{
		}

		public TankPartPaintInstanceComponent(GameObject paintInstance)
		{
			PaintInstance = paintInstance;
		}
	}
}
