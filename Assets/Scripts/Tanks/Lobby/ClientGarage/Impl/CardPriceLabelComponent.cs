using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class CardPriceLabelComponent : UIBehaviour
	{
		[SerializeField]
		private Text[] resourceCountTexts;
		[SerializeField]
		private GameObject[] spacingObjects;
		[SerializeField]
		private Color textColorWhenResourceEnough;
		[SerializeField]
		private Color textColorWhenResourceNotEnough;
	}
}
