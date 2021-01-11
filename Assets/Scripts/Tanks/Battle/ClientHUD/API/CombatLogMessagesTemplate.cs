using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Battle.ClientHUD.API
{
	[SerialVersionUID(635719605164895527L)]
	public interface CombatLogMessagesTemplate : Template
	{
		[AutoAdded]
		[PersistentConfig("", false)]
		CombatLogCommonMessagesComponent combatLogCommonMessages();

		[AutoAdded]
		[PersistentConfig("", false)]
		CombatLogDMMessagesComponent combatLogDMMessages();

		[AutoAdded]
		[PersistentConfig("", false)]
		CombatLogTDMMessagesComponent combatLogTDMMessages();

		[AutoAdded]
		[PersistentConfig("", false)]
		CombatLogCTFMessagesComponent combatLogCtfMessages();
	}
}
