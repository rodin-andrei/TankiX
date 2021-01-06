using UnityEngine.EventSystems;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.API
{
	public class UserListItemComponent : UIBehaviour
	{
		public long userId;
		[SerializeField]
		private GameObject userLabelPrefab;
		[SerializeField]
		private RectTransform userLabelRoot;
		public bool isVisible;
		public RectTransform viewportRect;
	}
}
