using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class GarageSlotsUIPanelComponent : BehaviourComponent
	{
		[SerializeField]
		private SlotUIComponent[] slots;
	}
}
