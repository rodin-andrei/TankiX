using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using TMPro;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ContainersUI : BehaviourComponent
	{
		[SerializeField]
		private Carousel carousel;
		[SerializeField]
		private TextMeshProUGUI title;
		[SerializeField]
		private TextMeshProUGUI openText;
		[SerializeField]
		private TextMeshProUGUI amount;
		[SerializeField]
		private LocalizedField containersAmountSingularText;
		[SerializeField]
		private LocalizedField containersAmountPlural1Text;
		[SerializeField]
		private LocalizedField containersAmountPlural2Text;
		[SerializeField]
		private LocalizedField openContainer;
		[SerializeField]
		private LocalizedField openAllContainers;
		[SerializeField]
		private GameObject openContainerBlock;
		[SerializeField]
		private TextMeshProUGUI openButtonText;
		[SerializeField]
		private BuyContainerButton buyButton;
		[SerializeField]
		private BuyContainerButton[] xBuyButtons;
		[SerializeField]
		private ContainerContentUI containerContent;
		[SerializeField]
		private Animator contentAnimator;
		[SerializeField]
		private GameObject previewButton;
		[SerializeField]
		private float contentCameraOffset;
		[SerializeField]
		private ContainerDescriptionUI containerDescription;
		[SerializeField]
		private bool blueprints;
		public bool previewMode;
	}
}
