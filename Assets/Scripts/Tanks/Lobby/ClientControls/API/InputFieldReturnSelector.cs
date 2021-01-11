using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientControls.API
{
	public class InputFieldReturnSelector : MonoBehaviour
	{
		public Selectable selectable;

		public InputField inputField;

		public InputFieldReturnSelector overridenSelector;

		protected virtual void Start()
		{
			if (overridenSelector != null)
			{
				overridenSelector.enabled = false;
			}
		}

		protected virtual bool CurrentInputSelected()
		{
			return EventSystem.current.currentSelectedGameObject == inputField.gameObject;
		}

		protected virtual void SelectCurrentInput()
		{
			inputField.Select();
		}

		private void LateUpdate()
		{
			if (CurrentInputSelected() && Input.GetKeyDown(KeyCode.Return))
			{
				ExecuteEvents.Execute(selectable.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
				SelectCurrentInput();
			}
		}

		public bool CanNavigateToSelectable()
		{
			return selectable.interactable;
		}
	}
}
