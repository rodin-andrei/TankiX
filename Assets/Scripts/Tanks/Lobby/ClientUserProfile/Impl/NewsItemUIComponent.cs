using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class NewsItemUIComponent : UIBehaviour
	{
		[SerializeField]
		private Text headerText;
		[SerializeField]
		private Text dateText;
		[SerializeField]
		private NewsImageContainerComponent imageContainer;
		[SerializeField]
		private RectTransform centralIconTransform;
		[SerializeField]
		private RectTransform saleIconTransform;
		[SerializeField]
		private Text saleIconText;
		[SerializeField]
		private GameObject border;
		public bool noSwap;
	}
}
