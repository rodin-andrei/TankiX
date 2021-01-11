using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Platform.Library.ClientResources.API
{
	public class AttachResourceEvent : Platform.Kernel.ECS.ClientEntitySystem.API.Event
	{
		public Object Data
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}
	}
}
