using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class CantChangeEquiptmentDialog : UIBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component, ICancelHandler, IEventSystemHandler
	{
		[SerializeField]
		private TextMeshProUGUI message;

		[SerializeField]
		private Button okButton;

		public LocalizedField messageLocalizedField;

		public void Show()
		{
			MainScreenComponent.Instance.Lock();
			message.text = messageLocalizedField.Value;
			base.gameObject.SetActive(true);
		}

		protected override void Start()
		{
			okButton.onClick.AddListener(OnOk);
		}

		private void OnOk()
		{
			Hide();
		}

		public void Hide()
		{
			MainScreenComponent.Instance.Unlock();
			GetComponent<Animator>().SetBool("Visible", false);
		}

		protected override void OnDisable()
		{
			base.gameObject.SetActive(false);
			GetComponent<Animator>().SetBool("Visible", false);
		}

		public void OnCancel(BaseEventData eventData)
		{
			Hide();
		}
	}
}
