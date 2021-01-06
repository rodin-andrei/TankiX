using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class CompetitionAwardWindowComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI _fractionNameText;
		[SerializeField]
		private TextMeshProUGUI _fractionRewardDescriptionText;
		[SerializeField]
		private ImageSkin _fractionRewardImage;
	}
}
