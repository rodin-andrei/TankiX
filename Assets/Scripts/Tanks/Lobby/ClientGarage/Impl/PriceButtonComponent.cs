using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class PriceButtonComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public long Price
		{
			get;
			set;
		}

		public PriceButtonComponent()
		{
		}

		public PriceButtonComponent(long price)
		{
			Price = price;
		}
	}
}
