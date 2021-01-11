using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientCommunicator.Impl
{
	public class ChatScreenComponent : BehaviourComponent
	{
		[SerializeField]
		private EntityBehaviour chatDialogBehaviour;

		public void BuildDialog()
		{
			chatDialogBehaviour.gameObject.SetActive(true);
		}
	}
}
