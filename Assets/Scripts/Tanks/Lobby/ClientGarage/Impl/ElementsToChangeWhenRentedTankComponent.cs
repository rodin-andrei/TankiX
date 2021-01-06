using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ElementsToChangeWhenRentedTankComponent : BehaviourComponent
	{
		[SerializeField]
		private GameObject[] elementsToHide;
		[SerializeField]
		private Button[] buttonsToDeactivate;
		[SerializeField]
		private GameObject[] elementsToActivate;
	}
}
