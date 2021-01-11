using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientNavigation.API
{
	public class NotificationDialogComponent : UIBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component, ICancelHandler, IEventSystemHandler
	{
		[SerializeField]
		private TextMeshProUGUI message;

		[SerializeField]
		private Button okButton;

		[Inject]
		public static EngineService EngineService
		{
			get;
			set;
		}

		public virtual void Show(string message)
		{
			this.message.text = message;
			base.gameObject.SetActive(true);
		}

		protected override void Start()
		{
			okButton.onClick.AddListener(OnOk);
		}

		private void OnOk()
		{
			Hide();
			if (GetComponent<EntityBehaviour>() != null)
			{
				Entity entity = GetComponent<EntityBehaviour>().Entity;
				EngineService.Engine.ScheduleEvent<DialogConfirmEvent>(entity);
			}
		}

		public void Hide()
		{
			GetComponent<Animator>().SetBool("Visible", false);
		}

		protected override void OnDisable()
		{
		}

		private void Update()
		{
			if (InputMapping.Cancel)
			{
				OnOk();
			}
		}

		public void OnCancel(BaseEventData eventData)
		{
			Hide();
		}
	}
}
