using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using Tanks.Lobby.ClientGarage.API;
using Tanks.Lobby.ClientMatchMaking.Impl;

namespace Tanks.Lobby.ClientMatchMaking.API
{
	[SerialVersionUID(1496982580733L)]
	public interface MatchMakingModeTemplate : ItemImagedTemplate, Template
	{
		[AutoAdded]
		MatchMakingModeComponent matchMakingMode();

		[AutoAdded]
		[PersistentConfig("", false)]
		MatchMakingModeRestrictionsComponent matchMakingModeRestrictions();

		[AutoAdded]
		[PersistentConfig("", false)]
		MatchMakingModeActivationComponent matchMakingModeActivation();

		[AutoAdded]
		[PersistentConfig("", false)]
		DescriptionItemComponent descriptionItem();

		[AutoAdded]
		[PersistentConfig("order", false)]
		OrderItemComponent OrderItem();
	}
}
