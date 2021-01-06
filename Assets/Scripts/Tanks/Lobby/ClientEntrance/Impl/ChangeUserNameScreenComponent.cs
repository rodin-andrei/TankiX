using Tanks.Lobby.ClientNavigation.API;
using UnityEngine.UI;
using UnityEngine;

namespace Tanks.Lobby.ClientEntrance.Impl
{
	public class ChangeUserNameScreenComponent : LocalizedScreenComponent
	{
		[SerializeField]
		private Text inputHint;
		[SerializeField]
		private Text continueButton;
		[SerializeField]
		private Text reservedNameHint;
	}
}
