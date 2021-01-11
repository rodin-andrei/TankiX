using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class UniversalPriceButtonComponent : BehaviourComponent
	{
		[SerializeField]
		private GameObject price;

		[SerializeField]
		private GameObject xPrice;

		public bool PriceActivity
		{
			get
			{
				return price.activeSelf;
			}
			set
			{
				price.SetActive(value);
			}
		}

		public bool XPriceActivity
		{
			get
			{
				return xPrice.activeSelf;
			}
			set
			{
				xPrice.SetActive(value);
			}
		}
	}
}
