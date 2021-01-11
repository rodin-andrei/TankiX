using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class TutorialArrow : MonoBehaviour
	{
		private RectTransform arrowPositionRect;

		private RectTransform thisRect;

		private void Awake()
		{
			thisRect = GetComponent<RectTransform>();
		}

		public void Setup(RectTransform arrowPositionRect)
		{
			this.arrowPositionRect = arrowPositionRect;
		}

		private void Update()
		{
			thisRect.pivot = arrowPositionRect.pivot;
			thisRect.sizeDelta = arrowPositionRect.sizeDelta;
			thisRect.position = arrowPositionRect.position;
			thisRect.rotation = arrowPositionRect.rotation;
		}
	}
}
