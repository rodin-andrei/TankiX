using Platform.Library.ClientUnityIntegration.API;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class BuyItemPacksButtonsComponent : BehaviourComponent
	{
		[SerializeField]
		private List<EntityBehaviour> buyButtons;
	}
}
