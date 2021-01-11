using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ChangeEmailDialogComponent : ConfirmDialogComponent
	{
		[SerializeField]
		private GameObject input;

		[SerializeField]
		private GameObject confirm;

		[SerializeField]
		private Button button;

		[SerializeField]
		private TextMeshProUGUI hintLabel;

		[SerializeField]
		private TextMeshProUGUI confirmationHintLabel;

		[SerializeField]
		private LocalizedField hint;

		[SerializeField]
		private LocalizedField confirmationHint;

		[SerializeField]
		private PaletteColorField emailColor;

		[SerializeField]
		private TMP_InputField inputField;

		protected override void OnEnable()
		{
			base.OnEnable();
			ShowInput();
			button.interactable = false;
		}

		private void ShowInput()
		{
			confirm.SetActive(false);
			input.SetActive(true);
			inputField.ActivateInputField();
		}

		public void ShowEmailConfirm(string email)
		{
			confirmationHintLabel.text = confirmationHint.Value.Replace("%EMAIL%", "<color=#" + emailColor.Color.ToHexString() + ">" + email + "</color>");
			input.SetActive(false);
			confirm.SetActive(true);
		}

		public void SetActiveHint(bool value)
		{
			hintLabel.text = ((!value) ? string.Empty : hint.Value);
			hintLabel.rectTransform.sizeDelta = new Vector2(hintLabel.rectTransform.sizeDelta.x, (!value) ? 30 : 80);
		}
	}
}
