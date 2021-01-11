using System.Collections.Generic;
using Platform.Library.ClientDataStructures.API;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.API
{
	public class UserNotificatorHUDComponent : BehaviourComponent
	{
		private enum ServiceMessageHUDState
		{
			IDLE,
			FADE_IN,
			FADE_OUT
		}

		[SerializeField]
		private UserRankNotificationMessageBehaviour userRankNotificationMessagePrefab;

		[SerializeField]
		private CanvasGroup serviseMessagesCanvasGroup;

		[SerializeField]
		private float serviceMessagesFadeTime = 0.5f;

		private ServiceMessageHUDState serviceMessageState;

		private float fadeSpeed;

		private Queue<BaseUserNotificationMessageBehaviour> messagesQueue;

		private BaseUserNotificationMessageBehaviour activeNotification;

		public UserRankNotificationMessageBehaviour UserRankNotificationMessagePrefab
		{
			get
			{
				return userRankNotificationMessagePrefab;
			}
		}

		private void OnEnable()
		{
			GetComponentsInChildren<BaseUserNotificationMessageBehaviour>(true).ForEach(delegate(BaseUserNotificationMessageBehaviour m)
			{
				Object.DestroyObject(m.gameObject);
			});
			serviseMessagesCanvasGroup.alpha = 1f;
			serviceMessageState = ServiceMessageHUDState.IDLE;
			fadeSpeed = 1f / serviceMessagesFadeTime;
			messagesQueue = new Queue<BaseUserNotificationMessageBehaviour>();
		}

		private void OnUserNotificationFadeOut()
		{
			activeNotification = null;
			if (messagesQueue.Count > 0)
			{
				activeNotification = messagesQueue.Dequeue();
				PlayNextNotification();
			}
			else
			{
				serviceMessageState = ServiceMessageHUDState.FADE_IN;
			}
		}

		private void Update()
		{
			if (serviceMessageState == ServiceMessageHUDState.IDLE)
			{
				return;
			}
			if (serviceMessageState == ServiceMessageHUDState.FADE_IN)
			{
				if (serviseMessagesCanvasGroup.alpha >= 1f)
				{
					serviseMessagesCanvasGroup.alpha = 1f;
					serviceMessageState = ServiceMessageHUDState.IDLE;
				}
				else
				{
					serviseMessagesCanvasGroup.alpha += fadeSpeed * Time.deltaTime;
				}
			}
			else if (serviceMessageState == ServiceMessageHUDState.FADE_OUT)
			{
				if (serviseMessagesCanvasGroup.alpha <= 0f)
				{
					serviseMessagesCanvasGroup.alpha = 0f;
					serviceMessageState = ServiceMessageHUDState.IDLE;
					PlayNextNotification();
				}
				else
				{
					serviseMessagesCanvasGroup.alpha -= fadeSpeed * Time.deltaTime;
				}
			}
		}

		public void Push(BaseUserNotificationMessageBehaviour notification)
		{
			serviceMessageState = ServiceMessageHUDState.FADE_OUT;
			if (activeNotification == null)
			{
				activeNotification = notification;
			}
			else
			{
				messagesQueue.Enqueue(notification);
			}
		}

		private void PlayNextNotification()
		{
			activeNotification.Play();
		}
	}
}
