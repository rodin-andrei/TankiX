using Tanks.Lobby.ClientNavigation.API;
using UnityEngine.UI;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class ChangeUserEmailScreenComponent : LocalizedScreenComponent
	{
		[SerializeField]
		private Text sendButtonText;
		[SerializeField]
		private Text rightPanelHint;
	}
}
