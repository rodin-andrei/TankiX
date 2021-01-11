using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class StartMaterialsComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Material[] Materials
		{
			get;
			set;
		}
	}
}
