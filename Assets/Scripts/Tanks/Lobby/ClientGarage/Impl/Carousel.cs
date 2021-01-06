using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class Carousel : ECSBehaviour
	{
		[SerializeField]
		private RectTransform content;
		[SerializeField]
		private float scrollThreshold;
		[SerializeField]
		private GarageItemUI itemPrefab;
		[SerializeField]
		private int selectedItem;
		[SerializeField]
		private float scrollSpeed;
		[SerializeField]
		private float fitDuration;
		[SerializeField]
		private float inputThreshold;
	}
}
