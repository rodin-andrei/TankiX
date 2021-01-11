using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class NotificationsStackContainerComponent : UIBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private float resetDelay = 15f;

		[SerializeField]
		private float yOffset = 100f;

		private float lastResetTime;

		private float lastOffset;

		public GameObject CreateNotification(GameObject prefab)
		{
			if (lastResetTime + resetDelay < Time.time)
			{
				lastOffset = 0f;
				lastResetTime = Time.time;
			}
			else
			{
				lastOffset += yOffset;
			}
			GameObject gameObject = Object.Instantiate(prefab, base.transform, false);
			RectTransform rectTransform = (RectTransform)gameObject.transform;
			Vector2 anchoredPosition = rectTransform.anchoredPosition;
			anchoredPosition.y += lastOffset;
			rectTransform.anchoredPosition = anchoredPosition;
			gameObject.SetActive(true);
			return gameObject;
		}
	}
}
