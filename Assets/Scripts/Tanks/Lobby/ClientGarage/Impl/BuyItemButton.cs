using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class BuyItemButton : MonoBehaviour
	{
		[SerializeField]
		private GaragePrice enabledPrice;
		[SerializeField]
		private GaragePrice disabledPrice;
		[SerializeField]
		private Button button;
	}
}
