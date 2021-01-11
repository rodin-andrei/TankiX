using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Lobby.ClientGarage.API
{
	[SerialVersionUID(1504698500736L)]
	public interface TutorialSelectItemDataTemplate : Template
	{
		[AutoAdded]
		[PersistentConfig("", false)]
		TutorialStepDataComponent tutorialStepData();

		[AutoAdded]
		[PersistentConfig("", false)]
		TutorialSelectItemDataComponent tutorialSelectItemData();
	}
}
