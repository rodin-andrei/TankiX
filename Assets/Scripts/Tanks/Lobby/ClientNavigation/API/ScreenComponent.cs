using System.Collections;
using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientNavigation.API
{
	public class ScreenComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private bool logInHistory = true;

		[SerializeField]
		private bool showHangar = true;

		[SerializeField]
		private bool rotateHangarCamera = true;

		[SerializeField]
		private bool showItemNotifications = true;

		[SerializeField]
		[HideInInspector]
		[FormerlySerializedAs("visibleTopPanelItems")]
		private List<string> visibleCommonScreenElements = new List<string>();

		[SerializeField]
		private bool showNotifications = true;

		[Tooltip("Элемент экрана, который должен быть выбран по умолчанию")]
		[SerializeField]
		private Selectable defaultControl;

		private CanvasGroup canvasGroup;

		public List<string> VisibleCommonScreenElements
		{
			get
			{
				return visibleCommonScreenElements;
			}
		}

		public bool LogInHistory
		{
			get
			{
				return logInHistory;
			}
		}

		public bool ShowHangar
		{
			get
			{
				return showHangar;
			}
		}

		public bool RotateHangarCamera
		{
			get
			{
				return rotateHangarCamera;
			}
		}

		public bool ShowItemNotifications
		{
			get
			{
				return showItemNotifications;
			}
		}

		public bool ShowNotifications
		{
			get
			{
				return showNotifications;
			}
		}

		private void OnEnable()
		{
			StartCoroutine(DelayFocus());
		}

		private IEnumerator DelayFocus()
		{
			yield return new WaitForSeconds(0f);
			if (defaultControl != null)
			{
				EventSystem.current.SetSelectedGameObject(null);
				defaultControl.Select();
			}
		}

		private void Awake()
		{
			canvasGroup = GetComponent<CanvasGroup>();
			if (canvasGroup == null)
			{
				canvasGroup = base.gameObject.AddComponent<CanvasGroup>();
			}
		}

		private void Reset()
		{
			visibleCommonScreenElements.Add(TopPanelElements.HOME_BUTTON.ToString());
		}

		public void Lock()
		{
			canvasGroup.blocksRaycasts = false;
		}

		public void Unlock()
		{
			canvasGroup.blocksRaycasts = true;
		}
	}
}
