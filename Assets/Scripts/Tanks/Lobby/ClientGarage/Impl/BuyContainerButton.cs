using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using TMPro;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class BuyContainerButton : MonoBehaviour
	{
		[SerializeField]
		private LocalizedField buyText;
		[SerializeField]
		private TextMeshProUGUI text;
		[SerializeField]
		private GaragePrice price;
	}
}
