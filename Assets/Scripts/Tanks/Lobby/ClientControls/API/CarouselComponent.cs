using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class CarouselComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI text;
		[SerializeField]
		private CarouselButtonComponent backButton;
		[SerializeField]
		private CarouselButtonComponent frontButton;
		[SerializeField]
		private int templateIdLow;
		[SerializeField]
		private int templateIdHigh;
	}
}
