using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using UnityEngine;

namespace Platform.Library.ClientResources.API
{
	[SerialVersionUID(635824350735025226L)]
	public class ResourceDataComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public string Name
		{
			get;
			set;
		}

		public Object Data
		{
			get;
			set;
		}
	}
}
