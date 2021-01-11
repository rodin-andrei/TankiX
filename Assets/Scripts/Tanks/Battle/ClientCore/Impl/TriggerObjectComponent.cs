using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class TriggerObjectComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public GameObject TriggerObject
		{
			get;
			set;
		}

		public TriggerObjectComponent()
		{
		}

		public TriggerObjectComponent(GameObject triggerObject)
		{
			TriggerObject = triggerObject;
		}
	}
}
