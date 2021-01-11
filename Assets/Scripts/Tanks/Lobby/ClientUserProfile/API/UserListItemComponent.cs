using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientUserProfile.Impl;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientUserProfile.API
{
	public class UserListItemComponent : UIBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public long userId;

		[SerializeField]
		private GameObject userLabelPrefab;

		[SerializeField]
		private RectTransform userLabelRoot;

		private GameObject userLabelObject;

		public bool isVisible;

		public RectTransform viewportRect;

		private Animator animator;

		[Inject]
		public static EngineService EngineService
		{
			get;
			set;
		}

		protected override void Awake()
		{
			animator = GetComponent<Animator>();
		}

		public void ResetItem(long userId, bool delayedLoading = false)
		{
			CancelInvoke();
			this.userId = userId;
			isVisible = false;
			if (userLabelObject != null)
			{
				Object.Destroy(userLabelObject);
			}
			animator.SetBool("show", false);
			animator.SetBool("remove", false);
			if (delayedLoading)
			{
				Invoke("SetUserLabelVisible", 0.2f);
			}
			else
			{
				SetUserLabelVisible();
			}
		}

		private void SetUserLabelVisible()
		{
			isVisible = true;
			userLabelObject = Object.Instantiate(userLabelPrefab);
			userLabelObject = new UserLabelBuilder(userId, userLabelObject, null, false).AllowInBattleIcon().Build();
			UidIndicatorComponent componentInChildren = userLabelObject.GetComponentInChildren<UidIndicatorComponent>();
			if (string.IsNullOrEmpty(componentInChildren.Uid))
			{
				componentInChildren.OnUserUidInited.AddListener(UserInited);
			}
			else
			{
				UserInited();
			}
			Entity entity = userLabelObject.GetComponent<EntityBehaviour>().Entity;
			userLabelObject.GetComponent<RectTransform>().SetParent(userLabelRoot, false);
			userLabelObject.GetComponent<Button>().onClick.AddListener(delegate
			{
				EngineService.Engine.ScheduleEvent<UserLabelClickEvent>(entity);
			});
		}

		private void UserInited()
		{
			userLabelObject.GetComponentInChildren<UidIndicatorComponent>().OnUserUidInited.RemoveListener(UserInited);
			GetComponent<Animator>().SetBool("show", true);
		}

		protected override void OnDisable()
		{
			CancelInvoke();
			animator.SetBool("show", false);
			animator.SetBool("remove", false);
			GetComponent<CanvasGroup>().alpha = 0f;
		}
	}
}
