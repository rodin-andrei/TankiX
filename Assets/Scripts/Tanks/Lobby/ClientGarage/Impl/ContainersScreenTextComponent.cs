using Tanks.Lobby.ClientNavigation.API;
using UnityEngine.UI;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ContainersScreenTextComponent : LocalizedScreenComponent
	{
		[SerializeField]
		private Text containersButtonText;
		[SerializeField]
		private Text openContainerButtonText;
		[SerializeField]
		private Text openAllContainerButtonText;
		[SerializeField]
		private Text emptyListText;
	}
}
