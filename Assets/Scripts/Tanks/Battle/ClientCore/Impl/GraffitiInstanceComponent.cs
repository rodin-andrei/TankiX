using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class GraffitiInstanceComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public GameObject GraffitiInstance
		{
			get;
			set;
		}

		public GameObject GraffitiDecalObject
		{
			get;
			set;
		}

		public Renderer EmitRenderer
		{
			get;
			set;
		}

		public GraffitiInstanceComponent()
		{
		}

		public GraffitiInstanceComponent(GameObject graffitiInstance)
		{
			GraffitiInstance = graffitiInstance;
		}
	}
}
