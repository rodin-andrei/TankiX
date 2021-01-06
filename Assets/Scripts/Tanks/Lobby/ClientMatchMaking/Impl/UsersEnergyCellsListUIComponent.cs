using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientMatchMaking.Impl
{
	public class UsersEnergyCellsListUIComponent : BehaviourComponent
	{
		[SerializeField]
		private RectTransform content;
		[SerializeField]
		private UserEnergyCellUIComponent cell;
	}
}
