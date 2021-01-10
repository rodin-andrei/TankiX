using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientPaymentGUI.Impl.TankRent
{
	public class TankRentMainScreenElementsComponents : BehaviourComponent
	{
		[SerializeField]
		private GameObject tankRentScreen;
		public Button tankRentButton;
		public GameObject tankRentOffer;
	}
}
