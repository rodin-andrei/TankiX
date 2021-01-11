using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientEntrance.API;
using Tanks.Lobby.ClientNavigation.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientEntrance.Impl
{
	public class RegistrationScreenComponent : BehaviourComponent, NoScaleScreen
	{
		[SerializeField]
		private TMP_InputField uidInput;

		[SerializeField]
		private TMP_InputField passwordInput;

		[SerializeField]
		private TMP_InputField emailInput;

		public GameObject locker;

		public virtual string Uid
		{
			get
			{
				return uidInput.text;
			}
			set
			{
				uidInput.text = value;
			}
		}

		public virtual string Password
		{
			get
			{
				return passwordInput.text;
			}
		}

		public virtual string Email
		{
			get
			{
				return emailInput.text;
			}
			set
			{
				emailInput.text = value;
			}
		}

		public InteractivityPrerequisiteComponent GetUidInput()
		{
			return uidInput.GetComponent<InteractivityPrerequisiteComponent>();
		}

		public InteractivityPrerequisiteComponent GetEmailInput()
		{
			return emailInput.GetComponent<InteractivityPrerequisiteComponent>();
		}

		public void SetUidInputInteractable(bool interactable)
		{
			uidInput.interactable = interactable;
			if (interactable)
			{
				uidInput.GetComponent<Animator>().SetTrigger("Reset");
			}
			else
			{
				uidInput.GetComponent<Animator>().SetTrigger("Inactive");
			}
		}

		public void SetEmailInputInteractable(bool interactable)
		{
			emailInput.interactable = interactable;
			if (interactable)
			{
				emailInput.GetComponent<Animator>().SetTrigger("Reset");
			}
			else
			{
				emailInput.GetComponent<Animator>().SetTrigger("Inactive");
			}
		}

		private void Awake()
		{
		}

		private void OnEnable()
		{
			LockScreen(false);
		}

		public void LockScreen(bool value)
		{
			locker.SetActive(value);
		}
	}
}
