using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientNavigation.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ModalConfirmWindowComponent : LocalizedControl, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private string localizePath;

		[SerializeField]
		private Text confirmText;

		[SerializeField]
		private Text cancelText;

		[SerializeField]
		private Text headerText;

		[SerializeField]
		private Text mainText;

		[SerializeField]
		private Text additionalText;

		[SerializeField]
		private ImageSkin icon;

		[SerializeField]
		private Button confirmButton;

		[SerializeField]
		private Button cancelButton;

		[SerializeField]
		private RectTransform contentRoot;

		private Entity screen;

		private bool alive;

		[Inject]
		public new static EngineService EngineService
		{
			get;
			set;
		}

		public string ConfirmText
		{
			set
			{
				confirmText.text = value;
			}
		}

		public string CancelText
		{
			set
			{
				cancelText.text = value;
			}
		}

		public string HeaderText
		{
			get
			{
				return headerText.text;
			}
			set
			{
				headerText.text = value;
				headerText.gameObject.SetActive(!string.IsNullOrEmpty(value));
			}
		}

		public string MainText
		{
			get
			{
				return mainText.text;
			}
			set
			{
				mainText.text = value;
				mainText.gameObject.SetActive(!string.IsNullOrEmpty(value));
			}
		}

		public string AdditionalText
		{
			get
			{
				return additionalText.text;
			}
			set
			{
				additionalText.text = value;
				additionalText.gameObject.SetActive(!string.IsNullOrEmpty(value));
			}
		}

		public string SpriteUid
		{
			set
			{
				icon.SpriteUid = value;
			}
		}

		public RectTransform ContentRoot
		{
			get
			{
				return contentRoot;
			}
		}

		protected override string GetRelativeConfigPath()
		{
			return localizePath;
		}

		public void Show(Entity screen)
		{
			this.screen = screen;
			base.gameObject.SetActive(true);
			if (!screen.HasComponent<LockedScreenComponent>())
			{
				screen.AddComponent<LockedScreenComponent>();
			}
		}

		private void Start()
		{
			alive = true;
			confirmButton.onClick.AddListener(OnYes);
			cancelButton.onClick.AddListener(OnNo);
		}

		private void OnApplicationQuit()
		{
			alive = false;
		}

		private void OnYes()
		{
			Hide();
			SendEvent<DialogConfirmEvent>();
		}

		private void OnNo()
		{
			Hide();
			SendEvent<DialogDeclineEvent>();
		}

		private void SendEvent<T>() where T : Platform.Kernel.ECS.ClientEntitySystem.API.Event, new()
		{
			if (GetComponent<EntityBehaviour>() != null)
			{
				Entity entity = GetComponent<EntityBehaviour>().Entity;
				ScheduleEvent<T>(entity);
			}
		}

		public void Hide()
		{
			GetComponent<Animator>().SetBool("Visible", false);
			if (alive && screen.HasComponent<LockedScreenComponent>())
			{
				screen.RemoveComponent<LockedScreenComponent>();
			}
		}
	}
}
