using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public class MaterialArrayComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Material[] Materials
		{
			get;
			set;
		}

		public MaterialArrayComponent(Material[] materials)
		{
			Materials = materials;
		}
	}
}
