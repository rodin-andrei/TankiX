using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientCommunicator.Impl
{
	[RequireComponent(typeof(InputField))]
	public class InputFieldClearSelection : MonoBehaviour
	{
		private InputFieldComponent inputField;

		private bool needClear;

		private void Awake()
		{
			inputField = base.gameObject.GetComponent<InputFieldComponent>();
		}

		public void OnSelect()
		{
			needClear = true;
		}

		private void LateUpdate()
		{
			if (needClear)
			{
				inputField.InputField.selectionAnchorPosition = inputField.InputField.text.Length;
				inputField.InputField.selectionFocusPosition = inputField.InputField.text.Length;
				needClear = false;
			}
		}
	}
}
