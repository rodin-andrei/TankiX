using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using UnityEngine.UI;
using Tanks.Lobby.ClientGarage.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class TutorialShowTriggerComponent : BehaviourComponent
	{
		public enum EventTriggerType
		{
			Awake = 0,
			ClickAnyWhere = 1,
			ClickAnyWhereOrDelay = 2,
			CustomTrigger = 3,
		}

		[SerializeField]
		protected long tutorialId;
		[SerializeField]
		protected long stepId;
		public EventTriggerType triggerType;
		public TutorialType tutorialType;
		public GameObject[] highlightedRects;
		public RectTransform popupPositionRect;
		public bool useOverlay;
		public bool showArrow;
		public RectTransform arrowPositionRect;
		public Button selectable;
		public float cameraOffset;
		public float showDelay;
		public float triggerDelay;
		public Button triggerButton;
		public TutorialHideTriggerComponent tutorialHideTrigger;
		public TutorialStepHandler stepCustomHandler;
		public GameObject outlinePrefab;
		public bool useImageInPopup;
		public string imageUid;
		public bool inBattleMode;
		public string ignorableDialogName;
	}
}
