using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using Tanks.Lobby.ClientGarage.Impl;

namespace Tanks.Lobby.ClientGarage.API
{
	[SerialVersionUID(1435032375010L)]
	public interface GarageTemplate : Template
	{
		[AutoAdded]
		[PersistentConfig("", false)]
		ItemUpgradeExperiencesConfigComponent upgradeLevels();

		[AutoAdded]
		[PersistentConfig("", false)]
		SlotsTextsComponent slotsTexts();

		[AutoAdded]
		[PersistentConfig("", false)]
		ModuleTypesImagesComponent moduleTypesImages();

		[AutoAdded]
		[PersistentConfig("", false)]
		LocalizedVisualPropertiesComponent localizedVisualProperties();
	}
}
