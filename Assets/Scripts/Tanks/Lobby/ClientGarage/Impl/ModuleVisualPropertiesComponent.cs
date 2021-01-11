using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ModuleVisualPropertiesComponent : Component
	{
		public List<ModuleVisualProperty> Properties
		{
			get;
			set;
		}

		public ModuleVisualPropertiesComponent()
		{
			Properties = new List<ModuleVisualProperty>();
		}
	}
}
