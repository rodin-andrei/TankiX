using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class InviteFriendsListComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private GameObject friendsListItem;

		[SerializeField]
		private GameObject emptyListNotification;

		private List<string> friendsUids = new List<string>();

		public GameObject FriendsListItem
		{
			get
			{
				return friendsListItem;
			}
		}

		public GameObject EmptyListNotification
		{
			get
			{
				return emptyListNotification;
			}
		}

		public List<string> FriendsUids
		{
			get
			{
				return friendsUids;
			}
		}
	}
}
