using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class VisualPropertiesComponent : Component
	{
		public string Feature
		{
			get;
			set;
		}

		public List<MainVisualProperty> MainProperties
		{
			get;
			set;
		}

		public List<VisualProperty> Properties
		{
			get;
			set;
		}

		public VisualPropertiesComponent()
		{
			MainProperties = new List<MainVisualProperty>();
			Properties = new List<VisualProperty>();
		}
	}
}
