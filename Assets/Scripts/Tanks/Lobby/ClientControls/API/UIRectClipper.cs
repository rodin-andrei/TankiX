using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class UIRectClipper : MonoBehaviour
	{
		[SerializeField]
		private float fromX;
		[SerializeField]
		private float toX;
		[SerializeField]
		private RectTransform.Axis axis;
	}
}
