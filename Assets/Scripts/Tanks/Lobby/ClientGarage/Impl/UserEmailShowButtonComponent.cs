using Platform.Library.ClientUnityIntegration.API;
using UnityEngine.UI;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class UserEmailShowButtonComponent : BehaviourComponent
	{
		[SerializeField]
		private Image icon;
		[SerializeField]
		private Color visibleColor;
		[SerializeField]
		private Color invisibleColor;
	}
}
