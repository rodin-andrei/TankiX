using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using Tanks.Lobby.ClientBattleSelect.Impl;
using Tanks.Lobby.ClientNavigation.API;

namespace Tanks.Lobby.ClientBattleSelect.API
{
	[SerialVersionUID(635754216736135597L)]
	public interface BattleSelectScreenTemplate : ScreenTemplate, Template
	{
		BattleSelectScreenComponent battleSelectScreen();

		BattleSelectLoadedComponent battleSelectLoaded();

		[AutoAdded]
		VisibleItemsRangeComponent visibleItemsRange();

		[AutoAdded]
		[PersistentConfig("", false)]
		BattleSelectScreenHeaderTextComponent battleSelectScreenHeaderText();

		[AutoAdded]
		[PersistentConfig("", false)]
		ScoreTableEmptyRowTextComponent scoreTableEmptyRowText();

		[PersistentConfig("", false)]
		BattleSelectScreenLocalizationComponent battleSelectScreenLocalization();

		[AutoAdded]
		[PersistentConfig("", false)]
		InviteFriendsConfigComponent inviteFriendsConfig();

		[PersistentConfig("", false)]
		InviteFriendsPanelLocalizationComponent inviteFriendsPanelLocalization();
	}
}
