using Platform.Library.ClientUnityIntegration.API;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class ShopBadgeComponent : BehaviourComponent
	{
		[Serializable]
		private class PromoBadge
		{
			public string Key;
			public Sprite Sprite;
		}

		[SerializeField]
		private Image saleIcon;
		[SerializeField]
		private Image specialIcon;
		[SerializeField]
		private Image promoIcon;
		[SerializeField]
		private List<ShopBadgeComponent.PromoBadge> promoBadges;
	}
}
