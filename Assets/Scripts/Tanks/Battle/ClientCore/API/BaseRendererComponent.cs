using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	public class BaseRendererComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Renderer Renderer
		{
			get;
			set;
		}

		public Mesh Mesh
		{
			get;
			set;
		}
	}
}
