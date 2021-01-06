using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientCommunicator.Impl
{
	public class ChatMessageUIComponent : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI firstPartText;
		[SerializeField]
		private TextMeshProUGUI secondPartText;
		public bool showed;
	}
}
