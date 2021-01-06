using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class NewsItemsRotatorBehaviour : UIBehaviour
	{
		public float swapPeriod;
		public float swapTime;
		public bool swapTrigger;
		public RectMask2D mask;
	}
}
