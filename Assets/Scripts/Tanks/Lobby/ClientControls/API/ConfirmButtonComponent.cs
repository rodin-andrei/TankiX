using System.Collections;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientControls.API
{
	[RequireComponent(typeof(Animator))]
	public class ConfirmButtonComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		public Button button;

		[SerializeField]
		private Text buttonText;

		[SerializeField]
		private Text confirmText;

		[SerializeField]
		private Text cancelText;

		[SerializeField]
		private Button defaultButton;

		private bool enableOutsideClicking;

		public bool EnableOutsideClicking
		{
			get
			{
				return enableOutsideClicking;
			}
		}

		public string ButtonText
		{
			get
			{
				return buttonText.text;
			}
			set
			{
				buttonText.text = value;
			}
		}

		public string ConfirmText
		{
			get
			{
				return confirmText.text;
			}
			set
			{
				confirmText.text = value;
			}
		}

		public string CancelText
		{
			get
			{
				return cancelText.text;
			}
			set
			{
				cancelText.text = value;
			}
		}

		public void FlipFront()
		{
			GetComponent<Animator>().SetBool("flip", false);
			StartCoroutine(DelayActivation(button));
		}

		public void FlipBack()
		{
			GetComponent<Animator>().SetBool("flip", true);
			StartCoroutine(DelayActivation(defaultButton));
		}

		public void Confirm()
		{
			GetComponent<Animator>().SetTrigger("confirm");
		}

		private IEnumerator DelayActivation(Button button)
		{
			while (!button.isActiveAndEnabled)
			{
				yield return new WaitForEndOfFrame();
			}
			button.Select();
		}

		private void DisableOutsideClickingOption()
		{
			enableOutsideClicking = false;
		}

		private void EnableOutsideClickingOption()
		{
			enableOutsideClicking = true;
		}
	}
}
