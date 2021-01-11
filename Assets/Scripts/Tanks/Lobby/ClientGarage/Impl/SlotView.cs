using System.Collections;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientGarage.Impl.Tutorial;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class SlotView : MonoBehaviour
	{
		public int moduleCard3DScale;

		public TooltipShowBehaviour tooltip;

		public Image dropInnerGlow;

		public Image dropOuterGlow;

		private DragAndDropCell dragAndDropCell;

		private void Awake()
		{
			dragAndDropCell = GetComponent<DragAndDropCell>();
			if ((bool)dropInnerGlow)
			{
				dropInnerGlow.gameObject.SetActive(false);
			}
			if ((bool)dropOuterGlow)
			{
				dropOuterGlow.gameObject.SetActive(false);
			}
		}

		public virtual void SetItem(SlotItemView item)
		{
			item.transform.SetParent(base.transform, false);
			UpdateItemTransform(item);
		}

		protected void UpdateItemTransform(SlotItemView item)
		{
			item.GetComponent<RectTransform>().anchoredPosition3D = Vector3.zero;
			item.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
			item.SetScaleToCard3D(moduleCard3DScale);
		}

		public void OnItemPlace(DragAndDropItem item)
		{
			SlotItemView component = item.GetComponent<SlotItemView>();
			UpdateItemTransform(component);
			component.HighlightEnable = true;
		}

		public void TurnOnRenderAboveAll()
		{
			if (!ModulesTutorialUtil.TUTORIAL_MODE)
			{
				StartCoroutine(DelayedTurnOnRenderAboveAll());
			}
		}

		private IEnumerator DelayedTurnOnRenderAboveAll()
		{
			yield return new WaitForEndOfFrame();
			RectTransform rectTransform = base.gameObject.GetComponent<RectTransform>();
			Vector3 pos = rectTransform.anchoredPosition3D;
			pos.z = NewModulesScreenUIComponent.OVER_SCREEN_Z_OFFSET;
			rectTransform.anchoredPosition3D = pos;
			Canvas canvas = base.gameObject.GetComponent<Canvas>();
			if (canvas == null)
			{
				canvas = base.gameObject.AddComponent<Canvas>();
			}
			canvas.renderMode = RenderMode.WorldSpace;
			canvas.overrideSorting = true;
			canvas.sortingOrder = 30;
			base.gameObject.AddComponent<GraphicRaycaster>();
			CanvasGroup canvasGroup = base.gameObject.AddComponent<CanvasGroup>();
			canvasGroup.blocksRaycasts = true;
			canvasGroup.ignoreParentGroups = true;
			canvasGroup.interactable = false;
		}

		public void TurnOffRenderAboveAll()
		{
			StopAllCoroutines();
			if (!ModulesTutorialUtil.TUTORIAL_MODE && base.gameObject.GetComponent<Canvas>() != null)
			{
				Object.Destroy(base.gameObject.GetComponent<GraphicRaycaster>());
				Object.Destroy(base.gameObject.GetComponent<Canvas>());
				Object.Destroy(base.gameObject.GetComponent<CanvasGroup>());
				RectTransform component = base.gameObject.GetComponent<RectTransform>();
				Vector3 anchoredPosition3D = component.anchoredPosition3D;
				anchoredPosition3D.z = 0f;
				component.anchoredPosition3D = anchoredPosition3D;
			}
		}

		public void HighlightForDrop()
		{
			SlotItemView item = GetItem();
			if (item != null)
			{
				dropOuterGlow.gameObject.SetActive(true);
				item.HighlightEnable = false;
			}
			else
			{
				dropInnerGlow.gameObject.SetActive(true);
			}
		}

		public void CancelHighlightForDrop()
		{
			dropInnerGlow.gameObject.SetActive(false);
			dropOuterGlow.gameObject.SetActive(false);
			SlotItemView item = GetItem();
			if (item != null)
			{
				item.HighlightEnable = true;
			}
		}

		public bool HasItem()
		{
			return dragAndDropCell.GetItem() != null;
		}

		public SlotItemView GetItem()
		{
			DragAndDropItem item = dragAndDropCell.GetItem();
			return (!(item == null)) ? item.GetComponent<SlotItemView>() : null;
		}
	}
}
