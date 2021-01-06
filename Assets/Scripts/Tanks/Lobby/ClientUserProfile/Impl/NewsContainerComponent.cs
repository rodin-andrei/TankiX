using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class NewsContainerComponent : BehaviourComponent
	{
		public GameObject newsItemPrefab;
		public RectTransform smallItems;
		public RectTransform mediumItems;
		public RectTransform largeItems;
		public RectTransform row1;
		public RectTransform row2;
	}
}
