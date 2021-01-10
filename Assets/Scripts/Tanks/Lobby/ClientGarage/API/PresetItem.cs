using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientGarage.API
{
	public class PresetItem
	{
		public PresetItem(string name, int level, string hullName, string turretName, long hullId, long weaponId, Entity presetEntity)
		{
		}

		public string Name;
		public int level;
		public bool isSelected;
		public string hullName;
		public string turretName;
		public long hullId;
		public long weaponId;
	}
}
