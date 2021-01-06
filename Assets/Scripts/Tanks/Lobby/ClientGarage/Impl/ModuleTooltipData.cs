using System.Collections.Generic;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ModuleTooltipData
	{
		public ModuleTooltipData(string name, string desc, int upgradeLevel, int maxLevel, List<ModuleVisualProperty> properties)
		{
		}

		public string name;
		public string desc;
		public int upgradeLevel;
		public int maxLevel;
	}
}
