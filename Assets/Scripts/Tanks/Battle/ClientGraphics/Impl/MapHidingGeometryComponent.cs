using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class MapHidingGeometryComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Renderer[] hidingRenderers;

		public MapHidingGeometryComponent()
		{
		}

		public MapHidingGeometryComponent(Renderer[] hidingRenderers)
		{
			this.hidingRenderers = hidingRenderers;
		}
	}
}
