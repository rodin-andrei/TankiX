using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class CameraTargetComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public GameObject TargetObject
		{
			get;
			set;
		}

		public CameraTargetComponent()
		{
		}

		public CameraTargetComponent(GameObject targetObject)
		{
			TargetObject = targetObject;
		}
	}
}
