using System;
using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientNavigation.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ConfirmDialogComponent : BaseDialogComponent
	{
		private List<Animator> animators;

		public Action dialogClosed;

		private bool _show;

		public bool show
		{
			get
			{
				return _show;
			}
			set
			{
				_show = value;
			}
		}

		protected virtual void OnEnable()
		{
			CanvasGroup componentInChildren = GetComponentInChildren<CanvasGroup>();
			if (componentInChildren != null)
			{
				componentInChildren.alpha = 0f;
			}
			Animator component = GetComponent<Animator>();
			if (component != null)
			{
				component.SetBool("show", true);
			}
			if (animators == null)
			{
				return;
			}
			foreach (Animator animator in animators)
			{
				animator.SetBool("Visible", false);
			}
		}

		public override void Show(List<Animator> animtrs = null)
		{
			if (MainScreenComponent.Instance != null)
			{
				MainScreenComponent.Instance.OverrideOnBack(Hide);
			}
			if (animtrs == null)
			{
				animtrs = new List<Animator>();
			}
			animators = animtrs;
			show = true;
			if (base.gameObject.activeInHierarchy)
			{
				OnEnable();
			}
			else
			{
				base.gameObject.SetActive(true);
			}
		}

		public override void Hide()
		{
			if (show)
			{
				MainScreenComponent.Instance.ClearOnBackOverride();
				show = false;
				Animator component = GetComponent<Animator>();
				if (component != null)
				{
					component.SetBool("show", false);
				}
				ShowHiddenScreenParts();
			}
		}

		protected void ShowHiddenScreenParts()
		{
			if (animators == null)
			{
				return;
			}
			foreach (Animator animator in animators)
			{
				animator.SetBool("Visible", true);
			}
			animators = null;
		}

		private void OnDisable()
		{
			ShowHiddenScreenParts();
		}

		public void HideImmediate()
		{
			Hide();
			OnHide();
		}

		public void OnHide()
		{
			if (show)
			{
				OnEnable();
				return;
			}
			if (dialogClosed != null)
			{
				dialogClosed();
			}
			base.gameObject.SetActive(false);
		}

		public virtual void OnShow()
		{
		}

		public void OnYes()
		{
			Hide();
			if (GetComponent<EntityBehaviour>() != null)
			{
				Entity entity = GetComponent<EntityBehaviour>().Entity;
				ScheduleEvent<DialogConfirmEvent>(entity);
			}
		}
	}
}
