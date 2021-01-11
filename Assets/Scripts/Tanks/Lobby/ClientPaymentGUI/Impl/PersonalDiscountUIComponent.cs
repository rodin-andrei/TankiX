using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientGarage.Impl;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class PersonalDiscountUIComponent : TextTimerComponent, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private TextMeshProUGUI description;

		public string Description
		{
			set
			{
				description.text = value;
			}
		}
	}
}
