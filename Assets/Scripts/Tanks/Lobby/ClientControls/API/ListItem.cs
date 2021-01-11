using UnityEngine;
using UnityEngine.EventSystems;

namespace Tanks.Lobby.ClientControls.API
{
	public class ListItem : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
	{
		public const string DISABLE_MESSAGE = "OnItemDisabled";

		public const string ENABLE_MESSAGE = "OnItemEnabled";

		private static int SELECTED_STATE = Animator.StringToHash("Selected");

		private static int ENABLED_STATE = Animator.StringToHash("Enabled");

		private bool pointerOver;

		[SerializeField]
		private RectTransform content;

		private ListItemContent cachedContent;

		private object data;

		private Animator animator;

		public object Data
		{
			get
			{
				return data;
			}
			set
			{
				data = value;
				if (cachedContent != null)
				{
					cachedContent.SetDataProvider(data);
				}
			}
		}

		private Animator Animator
		{
			get
			{
				if (animator == null)
				{
					animator = GetComponent<Animator>();
				}
				return animator;
			}
		}

		private void OnItemDisabled()
		{
			SetBool(ENABLED_STATE, false);
		}

		private void OnItemEnabled()
		{
			SetBool(ENABLED_STATE, true);
		}

		public void PlaySelectionAnimation()
		{
			SetBool(SELECTED_STATE, true);
		}

		public void PlayDeselectionAnimation()
		{
			SetBool(SELECTED_STATE, false);
		}

		private void SetBool(int state, bool value)
		{
			if (base.gameObject.activeInHierarchy && Animator.isActiveAndEnabled)
			{
				Animator.SetBool(state, value);
			}
		}

		public void SetContent(RectTransform content)
		{
			content.SetParent(this.content, false);
			content.gameObject.SetActive(false);
			content.gameObject.SetActive(true);
			cachedContent = content.GetComponent<ListItemContent>();
		}

		public void Select(bool sendMessage = true)
		{
			if (sendMessage)
			{
				SendMessageUpwards("OnItemSelect", this, SendMessageOptions.DontRequireReceiver);
			}
			PlaySelectionAnimation();
			if (cachedContent != null)
			{
				cachedContent.Select();
			}
		}

		public RectTransform GetContent()
		{
			if (content.childCount == 1)
			{
				return (RectTransform)content.GetChild(0);
			}
			return null;
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (eventData.clickCount > 1)
			{
				SendMessageUpwards("OnDoubleClick", this, SendMessageOptions.DontRequireReceiver);
			}
		}

		private void Update()
		{
			if (pointerOver)
			{
				SendMessageUpwards("PointerOverContentItem", this, SendMessageOptions.DontRequireReceiver);
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			pointerOver = true;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			pointerOver = false;
		}
	}
}
