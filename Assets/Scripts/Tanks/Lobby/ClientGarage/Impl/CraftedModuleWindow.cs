using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.ECS.ClientEntitySystem.Impl;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientGarage.API;
using Tanks.Lobby.ClientNavigation.API;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class CraftedModuleWindow : UIBehaviour, ICancelHandler, IEventSystemHandler
	{
		[SerializeField]
		private Text okText;

		[SerializeField]
		private Text moduleNameText;

		[SerializeField]
		private Text moduleDescriptionText;

		[SerializeField]
		private Text additionalText;

		[SerializeField]
		private Button okButton;

		[SerializeField]
		private ImageSkin icon;

		private Entity screen;

		private bool alive;

		private string newAdditionalText;

		[Inject]
		public static EngineService EngineService
		{
			get;
			set;
		}

		public string SpriteUid
		{
			set
			{
				icon.SpriteUid = value;
			}
		}

		public string ModuleNameText
		{
			set
			{
				moduleNameText.text = value;
			}
		}

		public string ModuleDescriptionText
		{
			set
			{
				moduleDescriptionText.text = value;
			}
		}

		public string AdditionalText
		{
			set
			{
				newAdditionalText = value;
			}
		}

		public string OkText
		{
			set
			{
				okText.text = value;
			}
		}

		public void Show(Entity screen, Entity module, Entity marketModule, Entity user)
		{
			MainScreenComponent.Instance.OverrideOnBack(Hide);
			Animator component = GetComponent<Animator>();
			this.screen = screen;
			if (!base.gameObject.activeSelf)
			{
				base.gameObject.SetActive(true);
				GetComponent<CanvasGroup>().alpha = 0f;
				component.SetTrigger("craft");
			}
			component.SetInteger("type", 0);
			if (!screen.HasComponent<LockedScreenComponent>())
			{
				screen.AddComponent<LockedScreenComponent>();
			}
		}

		private void GoToCards()
		{
			EngineService.Engine.ScheduleEvent(new ShowGarageItemEvent
			{
				Item = Flow.Current.EntityRegistry.GetEntity(-370755132L)
			}, screen);
		}

		protected override void Start()
		{
			alive = true;
			okButton.onClick.AddListener(Hide);
		}

		private void OnApplicationQuit()
		{
			alive = false;
		}

		public void Hide()
		{
			MainScreenComponent.Instance.ClearOnBackOverride();
			GetComponent<Animator>().SetTrigger("hide");
		}

		protected override void OnDisable()
		{
			if (alive && screen.HasComponent<LockedScreenComponent>())
			{
				screen.RemoveComponent<LockedScreenComponent>();
			}
		}

		private void ApplyText()
		{
			additionalText.text = newAdditionalText;
		}

		private void Update()
		{
			if (InputMapping.Cancel)
			{
				Hide();
			}
		}

		public void OnCancel(BaseEventData eventData)
		{
			Hide();
		}
	}
}
