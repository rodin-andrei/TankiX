using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientQuests.Impl
{
	public class QuestRewardGUIComponent : BehaviourComponent
	{
		[SerializeField]
		private ImageSkin rewardImageSkin;

		[SerializeField]
		private TextMeshProUGUI rewardInfoText;

		[SerializeField]
		private CanvasGroup rewardCanvasGroup;

		[SerializeField]
		private float rewardedAlpha;

		public string RewardInfoText
		{
			set
			{
				rewardInfoText.text = value;
			}
		}

		public void SetImage(string spriteUid)
		{
			rewardImageSkin.SpriteUid = spriteUid;
			rewardImageSkin.enabled = true;
		}

		public void SetRewarded()
		{
			rewardCanvasGroup.alpha = rewardedAlpha;
		}

		public void SetNotRewarded()
		{
			rewardCanvasGroup.alpha = 1f;
		}
	}
}
