using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.API
{
	public class UserLabelComponent : BehaviourComponent
	{
		[SerializeField]
		private long userId;
		public GameObject inBattleIcon;
	}
}
