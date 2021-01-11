using Tanks.Lobby.ClientControls.API;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.API
{
	public class FriendsUITableViewCell : UITableViewCell
	{
		[SerializeField]
		private UserListItemComponent friendsListItem;

		public long id
		{
			get
			{
				return friendsListItem.userId;
			}
		}

		public void Init(long userId, bool delayedLoading)
		{
			friendsListItem.ResetItem(userId, delayedLoading);
		}
	}
}
