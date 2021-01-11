using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public class MaterialComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Material Material
		{
			get;
			set;
		}

		public MaterialComponent(Material material)
		{
			Material = material;
		}
	}
}
