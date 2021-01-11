using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ScreenScaller : MonoBehaviour
	{
		[SerializeField]
		private int screenHeight;

		[SerializeField]
		private int aspectRatioX;

		[SerializeField]
		private int aspectRatioY;

		private void Update()
		{
			if (GetComponentInParent<Canvas>() != null)
			{
				GameObject gameObject = GetComponentInParent<Canvas>().gameObject;
				float height = gameObject.GetComponent<RectTransform>().rect.height;
				if ((float)aspectRatioX / (float)aspectRatioY > (float)Screen.width / (float)Screen.height)
				{
					GetComponent<RectTransform>().localScale = Vector3.one * screenHeight / height;
				}
				else
				{
					GetComponent<RectTransform>().localScale = Vector3.one * height / screenHeight;
				}
			}
		}
	}
}
