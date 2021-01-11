using System;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tanks.Lobby.ClientControls.API
{
	public class TooltipShowBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
	{
		[HideInInspector]
		public bool showTooltip = true;

		[HideInInspector]
		public bool customContentPrefab;

		[HideInInspector]
		public GameObject customPrefab;

		[HideInInspector]
		public bool defaultBackground = true;

		[HideInInspector]
		public bool overrideDelay;

		[HideInInspector]
		public float customDelay = 0.2f;

		public LocalizedField localizedTip;

		private float hoverTimer;

		private bool pointerIn;

		protected bool tooltipShowed;

		private Vector3 lastCursorPosition;

		protected string tipText = string.Empty;

		protected object customData;

		[Inject]
		public static EngineServiceInternal EngineService
		{
			get;
			set;
		}

		public string TipText
		{
			get
			{
				return tipText;
			}
			set
			{
				tipText = value;
			}
		}

		public void SetCustomContentData(object data)
		{
			if (!customContentPrefab)
			{
				throw new Exception("Couldn't set custom content data. You have to set custom prefab");
			}
			customData = data;
		}

		private void OnDisable()
		{
			HideTooltip();
		}

		protected virtual void Awake()
		{
			if (string.IsNullOrEmpty(tipText) && !string.IsNullOrEmpty(localizedTip.Value))
			{
				TipText = localizedTip.Value;
			}
		}

		public void UpdateTipText()
		{
			TipText = localizedTip.Value;
		}

		private void Update()
		{
			if (!HasShowData() || !showTooltip)
			{
				return;
			}
			if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
			{
				HideTooltip();
			}
			if (pointerIn && !tooltipShowed)
			{
				Vector3 mousePosition = Input.mousePosition;
				if (lastCursorPosition != mousePosition)
				{
					hoverTimer = 0f;
				}
				lastCursorPosition = mousePosition;
				hoverTimer += Time.deltaTime;
				float num = (overrideDelay ? customDelay : ((!TooltipController.Instance.quickShow) ? TooltipController.Instance.delayBeforeTooltipShowAfterCursorStop : TooltipController.Instance.delayBeforeQuickShow));
				if (hoverTimer >= num)
				{
					ShowTooltip(mousePosition);
				}
			}
		}

		private bool HasShowData()
		{
			return !string.IsNullOrEmpty(tipText) || (customContentPrefab && customData != null);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			pointerIn = true;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			HideTooltip();
		}

		public virtual void ShowTooltip(Vector3 mousePosition)
		{
			CheckForTutorialEvent checkForTutorialEvent = new CheckForTutorialEvent();
			EngineService.Engine.ScheduleEvent(checkForTutorialEvent, EngineService.EntityStub);
			if (!checkForTutorialEvent.TutorialIsActive)
			{
				tooltipShowed = true;
				if (customContentPrefab)
				{
					TooltipController.Instance.ShowTooltip(mousePosition, customData ?? tipText, customPrefab, defaultBackground);
				}
				else
				{
					TooltipController.Instance.ShowTooltip(mousePosition, tipText, null, defaultBackground);
				}
			}
		}

		public void HideTooltip()
		{
			pointerIn = false;
			hoverTimer = 0f;
			if (tooltipShowed)
			{
				TooltipController.Instance.HideTooltip();
			}
			tooltipShowed = false;
		}
	}
}
