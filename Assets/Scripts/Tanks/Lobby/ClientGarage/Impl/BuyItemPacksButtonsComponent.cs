using System.Collections.Generic;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class BuyItemPacksButtonsComponent : BehaviourComponent
	{
		[SerializeField]
		private List<EntityBehaviour> buyButtons;

		public List<EntityBehaviour> BuyButtons
		{
			get
			{
				return buyButtons;
			}
		}

		public void SetBuyButtonsInactive()
		{
			buyButtons.ForEach(delegate(EntityBehaviour button)
			{
				button.gameObject.SetActive(false);
			});
		}
	}
}
