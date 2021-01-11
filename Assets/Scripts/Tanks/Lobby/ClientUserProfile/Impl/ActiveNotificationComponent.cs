using System.Linq;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class ActiveNotificationComponent : BehaviourComponent
	{
		[SerializeField]
		private Animator animator;

		[SerializeField]
		private string showState = "Show";

		[SerializeField]
		private string hideState = "Hide";

		[SerializeField]
		private Text text;

		private bool visible;

		private Entity entity;

		public Entity Entity
		{
			get
			{
				return entity;
			}
			set
			{
				entity = value;
			}
		}

		public Animator Animator
		{
			get
			{
				return animator;
			}
		}

		public int ShowState
		{
			get;
			private set;
		}

		public int HideState
		{
			get;
			private set;
		}

		public Text Text
		{
			get
			{
				return text;
			}
		}

		public bool Visible
		{
			get
			{
				return visible;
			}
		}

		public ActiveNotificationComponent()
		{
			ShowState = Animator.StringToHash(showState);
			HideState = Animator.StringToHash(hideState);
		}

		public void Show()
		{
			visible = true;
			if (Animator != null)
			{
				Animator.Play(ShowState);
			}
		}

		public void Hide()
		{
			visible = false;
			if (Animator != null)
			{
				Animator.Play(HideState);
				if (Animator.parameters.Any((AnimatorControllerParameter p) => p.name.Equals("HideFlag")))
				{
					Animator.SetBool("HideFlag", true);
				}
			}
		}

		public void OnHidden()
		{
			ECSBehaviour.EngineService.Engine.ScheduleEvent<NotificationShownEvent>(entity);
		}
	}
}
