using UnityEngine;
using UnityEngine.EventSystems;

namespace Tanks.Lobby.ClientControls.API
{
	public class CursorSwitcher : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
	{
		private static GameObject overObject;

		public CursorType cursorType;

		public void OnPointerEnter(PointerEventData eventData)
		{
			if ((cursorType == CursorType.HAND && base.gameObject.IsInteractable()) || cursorType != 0)
			{
				Cursors.SwitchToCursor(cursorType);
				overObject = base.gameObject;
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			Cursors.SwitchToDefaultCursor();
		}

		private void OnDisable()
		{
			if (overObject == base.gameObject)
			{
				overObject = null;
				Cursors.SwitchToDefaultCursor();
			}
		}
	}
}
