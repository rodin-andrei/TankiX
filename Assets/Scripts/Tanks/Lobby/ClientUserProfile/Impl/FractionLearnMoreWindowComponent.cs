using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class FractionLearnMoreWindowComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI _competitionTitle;
		[SerializeField]
		private TextMeshProUGUI _competitionDescription;
		[SerializeField]
		private ImageSkin _competitionLogo;
	}
}
