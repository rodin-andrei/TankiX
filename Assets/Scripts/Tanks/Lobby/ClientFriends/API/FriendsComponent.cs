using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientFriends.API
{
	public class FriendsComponent : Component
	{
		public Dictionary<long, DateTime> InLobbyInvitations = new Dictionary<long, DateTime>();

		public Dictionary<long, DateTime> InSquadInvitations = new Dictionary<long, DateTime>();

		public HashSet<long> AcceptedFriendsIds
		{
			get;
			set;
		}

		public HashSet<long> IncommingFriendsIds
		{
			get;
			set;
		}

		public HashSet<long> OutgoingFriendsIds
		{
			get;
			set;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("\n[" + string.Join(", ", AcceptedFriendsIds.Select((long id) => id.ToString()).ToArray()) + "]\n");
			stringBuilder.Append("\n[" + string.Join(", ", IncommingFriendsIds.Select((long id) => id.ToString()).ToArray()) + "]\n");
			stringBuilder.Append("\n[" + string.Join(", ", OutgoingFriendsIds.Select((long id) => id.ToString()).ToArray()) + "]\n");
			return stringBuilder.ToString();
		}
	}
}
