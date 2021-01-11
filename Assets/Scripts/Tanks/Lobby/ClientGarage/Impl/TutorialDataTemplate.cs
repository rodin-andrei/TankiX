using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using Tanks.Lobby.ClientGarage.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	[SerialVersionUID(1504000056991L)]
	public interface TutorialDataTemplate : Template
	{
		[AutoAdded]
		[PersistentConfig("", false)]
		TutorialDataComponent tutorialData();

		[AutoAdded]
		[PersistentConfig("", false)]
		TutorialRequiredCompletedTutorialsComponent tutorialRequiredCompletedTutorials();

		[AutoAdded]
		TutorialGroupComponent tutorialGroup();
	}
}
