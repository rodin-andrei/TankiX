using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientGarage.Impl;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class WaitDialogComponent : UIBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public float maxTimerValue = 5f;

		private float _timer;

		[SerializeField]
		private Slider timerSlider;

		[SerializeField]
		private TextMeshProUGUI message;

		private CursorLockMode savedLockMode;

		private bool savedCursorVisible;

		private bool isShow;

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

		public virtual void Show(string messageText)
		{
			timer = 0f;
			MainScreenComponent.Instance.Lock();
			message.text = messageText;
			base.gameObject.SetActive(true);
			IsShow = true;
		}

		public void Hide()
		{
			IsShow = false;
			MainScreenComponent.Instance.Unlock();
			Object.Destroy(base.gameObject, 3f);
		}

		private void Update()
		{
			timer += Time.deltaTime;
			if (timer > maxTimerValue)
			{
				Hide();
			}
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
