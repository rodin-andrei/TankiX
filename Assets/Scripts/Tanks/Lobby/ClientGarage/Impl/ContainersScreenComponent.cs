using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ContainersScreenComponent : BehaviourComponent
	{
		[SerializeField]
		private GameObject openButton;

		[SerializeField]
		private GameObject openAllButton;

		[SerializeField]
		private GameObject rightPanel;

		[SerializeField]
		private GameObject emptyListText;

		[SerializeField]
		private GameObject contentButton;

		public GameObject OpenButton
		{
			get
			{
				return openButton;
			}
		}

		public GameObject OpenAllButton
		{
			get
			{
				return openAllButton;
			}
		}

		public bool OpenButtonActivity
		{
			get
			{
				return openButton.activeSelf;
			}
			set
			{
				openButton.SetActive(value);
				openButton.SetInteractable(value);
			}
		}

		public GameObject RightPanel
		{
			get
			{
				return rightPanel;
			}
		}

		public GameObject EmptyListText
		{
			get
			{
				return emptyListText;
			}
		}

		public bool ContentButtonActivity
		{
			get
			{
				return contentButton.activeSelf;
			}
			set
			{
				contentButton.SetActive(value);
				contentButton.SetInteractable(value);
			}
		}

		public void SetOpenButtonsActive(bool openActivity, bool openAllActivity)
		{
			openButton.SetActive(openActivity);
			openButton.SetInteractable(openActivity);
			openAllButton.SetActive(openAllActivity);
			openAllButton.SetInteractable(openAllActivity);
		}

		public void SetOpenButtonsInteractable(bool interactable)
		{
			openButton.SetInteractable(interactable);
			openAllButton.SetInteractable(interactable);
		}
	}
}
