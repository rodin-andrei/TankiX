using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ParachuteMaterialComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Material Material
		{
			get;
			set;
		}

		public ParachuteMaterialComponent(Material material)
		{
			Material = material;
		}
	}
}
