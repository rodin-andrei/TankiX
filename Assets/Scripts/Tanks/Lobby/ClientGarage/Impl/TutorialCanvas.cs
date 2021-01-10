using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class TutorialCanvas : MonoBehaviour
	{
		[SerializeField]
		public GameObject overlay;
		[SerializeField]
		private TutorialIntroDialog introDialog;
		[SerializeField]
		public TutorialDialog dialog;
		[SerializeField]
		public TutorialArrow arrow;
		[SerializeField]
		private GameObject tutorialScreen;
		[SerializeField]
		private GameObject skipTutorialButton;
		[SerializeField]
		private CanvasGroup backgroundCanvasGroup;
		[SerializeField]
		private Canvas overlayCanvas;
		[SerializeField]
		private Camera outlineCamera;
		[SerializeField]
		private Camera tutorialCamera;
	}
}
