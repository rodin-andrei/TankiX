using UnityEngine;
using UnityEngine.EventSystems;

namespace tanks.modules.lobby.ClientControls.Scripts.API
{
	public class HideOnClickOutside : UIBehaviour, IPointerExitHandler, IPointerEnterHandler, IEventSystemHandler
	{
		private bool hasFocus;

		private void Update()
		{
			if (!hasFocus && (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1)))
			{
				base.gameObject.SetActive(false);
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			hasFocus = false;
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			hasFocus = true;
		}
	}
}
