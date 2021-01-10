using UnityEngine;
using Platform.Library.ClientUnityIntegration.API;

namespace Tanks.Lobby.ClientControls.API
{
	public class SimpleHorizontalListComponent : MonoBehaviour
	{
		[SerializeField]
		private RectTransform horizontalLayoutGroup;
		[SerializeField]
		private RectTransform leftButtonPlace;
		[SerializeField]
		private RectTransform rightButtonPlace;
		[SerializeField]
		private RectTransform content;
		[SerializeField]
		private RectTransform scrollRect;
		[SerializeField]
		private ListItem itemPrefab;
		[SerializeField]
		private EntityBehaviour itemContentPrefab;
		[SerializeField]
		private RectTransform navigationButtonPrefab;
		[SerializeField]
		private float navigationButtonsScrollTime;
	}
}
