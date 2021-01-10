using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using TMPro;

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
	}
}
