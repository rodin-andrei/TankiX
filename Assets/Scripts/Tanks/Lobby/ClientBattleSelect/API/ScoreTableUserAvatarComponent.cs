using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.API
{
	public class ScoreTableUserAvatarComponent : BehaviourComponent
	{
		[SerializeField]
		private bool enableShowUserProfileOnAvatarClick;

		public bool EnableShowUserProfileOnAvatarClick
		{
			get
			{
				return enableShowUserProfileOnAvatarClick;
			}
		}
	}
}
