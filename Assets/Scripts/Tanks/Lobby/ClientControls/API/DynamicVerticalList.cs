using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class DynamicVerticalList : MonoBehaviour
	{
		[SerializeField]
		private RectTransform item;
		[SerializeField]
		private RectTransform itemContent;
		[SerializeField]
		private int itemHeight;
		[SerializeField]
		private int spacing;
		[SerializeField]
		private RectTransform viewport;
	}
}
