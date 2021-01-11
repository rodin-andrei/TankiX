using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class PacksImagesComponent : Component
	{
		private Dictionary<long, List<string>> amountToImages;

		public Dictionary<long, List<string>> AmountToImages
		{
			get
			{
				return amountToImages;
			}
			set
			{
				amountToImages = value;
			}
		}
	}
}
