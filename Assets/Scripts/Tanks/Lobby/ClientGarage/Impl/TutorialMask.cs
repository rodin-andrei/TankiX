using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class TutorialMask : MonoBehaviour
	{
		private RectTransform targetRect;

		private RectTransform thisRect;

		private void Awake()
		{
			thisRect = GetComponent<RectTransform>();
		}

		public void Init(RectTransform targetRect)
		{
			this.targetRect = targetRect;
		}

		private void Update()
		{
			thisRect.pivot = targetRect.pivot;
			thisRect.position = targetRect.position;
			thisRect.sizeDelta = new Vector2(targetRect.rect.width, targetRect.rect.height);
		}
	}
}
