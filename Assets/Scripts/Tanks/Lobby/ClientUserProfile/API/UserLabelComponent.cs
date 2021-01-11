using Platform.Library.ClientProtocol.API;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.API
{
	[SerialVersionUID(635870034442836260L)]
	public class UserLabelComponent : BehaviourComponent
	{
		[SerializeField]
		private long userId;

		public GameObject inBattleIcon;

		public bool SkipLoadUserFromServer
		{
			get;
			set;
		}

		public bool AllowInBattleIcon
		{
			get;
			set;
		}

		public long UserId
		{
			get
			{
				return userId;
			}
			set
			{
				userId = value;
			}
		}
	}
}
