using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class InteractionTooltipContent : BehaviourComponent, ITooltipContent
	{
		[SerializeField]
		private GameObject responceMessagePrefab;

		private RectTransform rect;

		public virtual void Init(object data)
		{
		}

		protected virtual void Awake()
		{
			rect = GetComponent<RectTransform>();
		}

		public void Hide()
		{
			TooltipController.Instance.HideTooltip();
		}

		private bool PointerOutsideMenu()
		{
			return !RectTransformUtility.RectangleContainsScreenPoint(rect, Input.mousePosition);
		}

		public void Update()
		{
			bool flag = Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1);
			bool keyUp = Input.GetKeyUp(KeyCode.Escape);
			if ((flag && PointerOutsideMenu()) || keyUp)
			{
				Hide();
			}
		}

		protected void ShowResponse(string respondText)
		{
			GameObject gameObject = Object.Instantiate(responceMessagePrefab);
			gameObject.transform.SetParent(base.transform.parent.parent, false);
			gameObject.GetComponent<RectTransform>().position = Input.mousePosition;
			gameObject.GetComponentInChildren<TextMeshProUGUI>().text = respondText;
			gameObject.SetActive(true);
			float length = gameObject.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).length;
			Object.Destroy(gameObject, length);
		}
	}
}
