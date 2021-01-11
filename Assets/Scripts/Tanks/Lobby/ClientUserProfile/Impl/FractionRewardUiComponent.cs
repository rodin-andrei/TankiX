using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class FractionRewardUiComponent : BehaviourComponent
	{
		[SerializeField]
		private ImageSkin _rewardImage;

		public string RewardImageUid
		{
			set
			{
				_rewardImage.SpriteUid = value;
			}
		}
	}
}
