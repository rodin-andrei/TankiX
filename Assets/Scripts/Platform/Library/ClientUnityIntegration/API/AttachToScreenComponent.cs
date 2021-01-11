using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Platform.Library.ClientUnityIntegration.API
{
	public class AttachToScreenComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public EntityBehaviour JoinEntityBehaviour
		{
			get;
			set;
		}
	}
}
