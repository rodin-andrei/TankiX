using Tanks.Lobby.ClientControls.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ExpBarEndGlowImage : MonoBehaviour
	{
		[SerializeField]
		private float minX;

		[SerializeField]
		private float maxX;

		[SerializeField]
		private UIRectClipper clipper;

		[SerializeField]
		private GameObject icon;

		private RectTransform thisRect;

		private RectTransform parentRect;

		private void Awake()
		{
			thisRect = GetComponent<RectTransform>();
			parentRect = base.transform.parent.GetComponent<RectTransform>();
		}

		private void Update()
		{
			float num = parentRect.rect.width * clipper.ToX;
			bool active = num < maxX && num > minX;
			icon.SetActive(active);
			thisRect.anchoredPosition = new Vector2(num, 0f);
		}
	}
}
