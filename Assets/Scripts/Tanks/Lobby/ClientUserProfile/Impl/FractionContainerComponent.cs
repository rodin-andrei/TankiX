using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class FractionContainerComponent : BehaviourComponent
	{
		public enum FractionContainerTargets
		{
			PLAYER_FRACTION = 0,
			WINNER_FRACTION = 1,
		}

		[SerializeField]
		private ImageSkin _fractionLogo;
		[SerializeField]
		private TextMeshProUGUI _fractionTitle;
		[SerializeField]
		private CanvasGroup _canvasGroup;
		public FractionContainerTargets Target;
	}
}
