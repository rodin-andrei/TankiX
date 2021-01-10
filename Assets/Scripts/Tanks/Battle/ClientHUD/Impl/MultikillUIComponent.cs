using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using Platform.Library.ClientResources.API;
using Tanks.Lobby.ClientControls.API;
using TMPro;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class MultikillUIComponent : BehaviourComponent
	{
		[SerializeField]
		private Animator animator;
		[SerializeField]
		private AssetReference voiceReference;
		[SerializeField]
		private LocalizedField multikillText;
		[SerializeField]
		private LocalizedField streakText;
		[SerializeField]
		private TextMeshProUGUI multikillTextField;
		[SerializeField]
		private TextMeshProUGUI streakTextField;
		[SerializeField]
		private AnimatedLong scoreText;
		[SerializeField]
		private bool disableVoice;
	}
}
