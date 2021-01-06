using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.API
{
	public class SelfUserAvatarComponent : BehaviourComponent
	{
		[SerializeField]
		private ImageSkin avatar;
		[SerializeField]
		private ImageListSkin border;
		[SerializeField]
		private ImageListSkin rank;
	}
}
