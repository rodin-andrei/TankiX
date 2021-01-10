using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ContainersScreenComponent : BehaviourComponent
	{
		[SerializeField]
		private GameObject openButton;
		[SerializeField]
		private GameObject openAllButton;
		[SerializeField]
		private GameObject rightPanel;
		[SerializeField]
		private GameObject emptyListText;
		[SerializeField]
		private GameObject contentButton;
	}
}
