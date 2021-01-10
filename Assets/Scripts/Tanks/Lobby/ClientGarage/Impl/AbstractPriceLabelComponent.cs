using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class AbstractPriceLabelComponent : BehaviourComponent
	{
		public Color shortageColor;
		[SerializeField]
		private GameObject oldPrice;
		[SerializeField]
		private Text oldPriceText;
	}
}
