using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientFriends.Impl
{
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class IncomingFriendsCounterComponent : BehaviourComponent
	{
		private int count;

		public int Count
		{
			get
			{
				return count;
			}
			set
			{
				count = value;
				GetComponent<TextMeshProUGUI>().text = ((count <= 0) ? string.Empty : ("[" + count + "]"));
			}
		}
	}
}
