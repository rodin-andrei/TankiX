using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Lobby.ClientUserProfile.API
{
	[SerialVersionUID(1502712502830L)]
	public interface LeagueTemplate : Template
	{
		[AutoAdded]
		LeagueComponent league();

		[AutoAdded]
		[PersistentConfig("", false)]
		LeagueIconComponent leagueIcon();

		[AutoAdded]
		[PersistentConfig("", false)]
		LeagueNameComponent leagueName();

		[AutoAdded]
		[PersistentConfig("", false)]
		LeagueEnergyConfigComponent leagueEnergyConfig();

		TopLeagueComponent topLeague();

		[AutoAdded]
		[PersistentConfig("", false)]
		LeagueEnterNotificationTextsComponent leagueEnterNotificationTexts();
	}
}
