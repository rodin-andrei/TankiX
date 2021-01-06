using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class TutorialDialog : ECSBehaviour
	{
		[SerializeField]
		protected AnimatedText animatedText;
		[SerializeField]
		protected Image backgroundImage;
		[SerializeField]
		protected Button continueButton;
		[SerializeField]
		protected ImageSkin image;
		[SerializeField]
		private TextMeshProUGUI tutorialProgressLabel;
		[SerializeField]
		private GameObject characterBig;
		[SerializeField]
		private GameObject characterSmall;
		public bool continueOnClick;
		[SerializeField]
		private Material blurMaterial;
		[SerializeField]
		private LayerMask highlightLayer;
	}
}
