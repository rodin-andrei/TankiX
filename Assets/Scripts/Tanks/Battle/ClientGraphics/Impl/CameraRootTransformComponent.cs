using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class CameraRootTransformComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Transform Root
		{
			get;
			set;
		}

		public CameraRootTransformComponent(Transform root)
		{
			Root = root;
		}
	}
}
