using Tanks.Lobby.ClientControls.API;
using UnityEngine.UI;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ModuleButtonsComponent : LocalizedControl
	{
		[SerializeField]
		private Button mountButton;
		[SerializeField]
		private Button unmountButton;
		[SerializeField]
		private Button assembleButton;
		[SerializeField]
		private Button addResButton;
		[SerializeField]
		private Text assembleText;
		[SerializeField]
		private Text mountText;
		[SerializeField]
		private Text unmountText;
	}
}
