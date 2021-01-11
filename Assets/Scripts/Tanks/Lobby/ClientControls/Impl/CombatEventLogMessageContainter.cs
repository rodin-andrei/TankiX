using System.Collections.Generic;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientControls.Impl
{
	public class CombatEventLogMessageContainter : MonoBehaviour
	{
		[SerializeField]
		private int maxVisibleMessages = 5;

		[SerializeField]
		private CombatEventLogMessage messagePrefab;

		[SerializeField]
		private CombatEventLogText textPrefab;

		[SerializeField]
		private CombatEventLogUser userPrefab;

		[SerializeField]
		private TankPartItemIcon tankPartItemIconPrefab;

		[SerializeField]
		private RectTransform rectTransform;

		[SerializeField]
		private RectTransform rectTransformForMoving;

		[SerializeField]
		private VerticalLayoutGroup verticalLayout;

		public Vector2 anchoredPos;

		private readonly List<CombatEventLogMessage> visibleChildMessages = new List<CombatEventLogMessage>();

		public List<CombatEventLogMessage> VisibleChildMessages
		{
			get
			{
				return visibleChildMessages;
			}
		}

		public int MaxVisibleMessages
		{
			get
			{
				return maxVisibleMessages;
			}
		}

		public Vector2 AnchoredPosition
		{
			get
			{
				return rectTransformForMoving.anchoredPosition;
			}
			set
			{
				rectTransformForMoving.anchoredPosition = value;
			}
		}

		public int ChildCount
		{
			get
			{
				return rectTransform.childCount;
			}
		}

		public VerticalLayoutGroup VerticalLayout
		{
			get
			{
				return verticalLayout;
			}
		}

		public CombatEventLogUser UserPrefab
		{
			get
			{
				return userPrefab;
			}
		}

		private void Update()
		{
			anchoredPos = AnchoredPosition;
		}

		public CombatEventLogMessage GetMessageInstanceAndAttachToContainer()
		{
			CombatEventLogMessage combatEventLogMessage = Object.Instantiate(messagePrefab);
			combatEventLogMessage.RectTransform.SetParent(rectTransform, false);
			return combatEventLogMessage;
		}

		public CombatEventLogText GetTextInstance()
		{
			return Object.Instantiate(textPrefab);
		}

		public CombatEventLogUser GetUserInstance()
		{
			return Object.Instantiate(userPrefab);
		}

		public TankPartItemIcon GetImageInstance()
		{
			return Object.Instantiate(tankPartItemIconPrefab);
		}

		public void AddMessage(CombatEventLogMessage message)
		{
			visibleChildMessages.Add(message);
			message.ShowMessage();
		}

		public void DestroyMessage(CombatEventLogMessage message)
		{
			visibleChildMessages.Remove(message);
			Object.Destroy(message.gameObject);
		}

		public void Clear()
		{
			while (visibleChildMessages.Count > 0)
			{
				DestroyMessage(visibleChildMessages[0]);
			}
			rectTransformForMoving.anchoredPosition = Vector2.zero;
		}
	}
}
