using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.ECS.ClientEntitySystem.Impl;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Battle.ClientCore.Impl;
using Tanks.Battle.ClientHUD.Impl;
using Tanks.Lobby.ClientGarage.Impl;
using Tanks.Lobby.ClientNavigation.API;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class InviteDialogComponent : UIBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private GameObject buttons;

		[SerializeField]
		private GameObject keys;

		public float maxTimerValue = 5f;

		private float _timer;

		[SerializeField]
		private Slider timerSlider;

		private bool inBattle;

		[SerializeField]
		private TextMeshProUGUI message;

		[SerializeField]
		private Button acceptButton;

		[SerializeField]
		private Button declineButton;

		[SerializeField]
		private AudioSource sound;

		private CursorLockMode savedLockMode;

		private bool savedCursorVisible;

		private bool isShow;

		private bool intractable;

		[Inject]
		public static EngineService EngineService
		{
			get;
			set;
		}

		[Inject]
		public static InputManager InputManager
		{
			get;
			set;
		}

		private float timer
		{
			get
			{
				return _timer;
			}
			set
			{
				_timer = value;
				timerSlider.value = 1f - timer / maxTimerValue;
			}
		}

		private bool IsShow
		{
			get
			{
				return isShow;
			}
			set
			{
				GetComponent<Animator>().SetBool("show", value);
				isShow = value;
			}
		}

		public virtual void Show(string messageText, bool inBattle)
		{
			intractable = true;
			timer = 0f;
			MainScreenComponent.Instance.Lock();
			message.text = messageText;
			base.gameObject.SetActive(true);
			IsShow = true;
			this.inBattle = inBattle;
			buttons.SetActive(!inBattle);
			keys.SetActive(inBattle);
			if (sound != null)
			{
				sound.Play();
			}
		}

		protected override void Start()
		{
			acceptButton.onClick.AddListener(OnYes);
			declineButton.onClick.AddListener(OnNo);
		}

		private void OnYes()
		{
			if (intractable)
			{
				Hide();
				if (GetComponent<EntityBehaviour>() != null)
				{
					Entity entity = GetComponent<EntityBehaviour>().Entity;
					EngineService.Engine.ScheduleEvent<DialogConfirmEvent>(entity);
				}
			}
		}

		public void OnNo()
		{
			if (intractable)
			{
				Hide();
				if (GetComponent<EntityBehaviour>() != null)
				{
					Entity entity = GetComponent<EntityBehaviour>().Entity;
					EngineService.Engine.ScheduleEvent<DialogDeclineEvent>(entity);
				}
			}
		}

		public void Hide()
		{
			intractable = false;
			IsShow = false;
			MainScreenComponent.Instance.Unlock();
			Object.Destroy(base.gameObject, 3f);
		}

		private void Update()
		{
			timer += Time.deltaTime;
			if (timer > maxTimerValue)
			{
				OnNo();
			}
			if (InputMapping.Cancel)
			{
				OnNo();
			}
			else if (Input.GetKeyDown(KeyCode.Y) && inBattle && !ChatIsFocused())
			{
				OnYes();
			}
			else if (Input.GetKeyDown(KeyCode.N) && inBattle && !ChatIsFocused())
			{
				OnNo();
			}
		}

		private bool ChatIsFocused()
		{
			BattleChatFocusCheckEvent battleChatFocusCheckEvent = new BattleChatFocusCheckEvent();
			EngineService.Engine.ScheduleEvent(battleChatFocusCheckEvent, new EntityStub());
			return battleChatFocusCheckEvent.InputIsFocused;
		}

		private void OnHideAnimationEvent()
		{
			if (!IsShow)
			{
				base.gameObject.SetActive(false);
			}
		}
	}
}
