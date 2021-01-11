using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	[RequireComponent(typeof(CanvasGroup))]
	[RequireComponent(typeof(Animator))]
	public class VisibilityPrerequisitesComponent : BehaviourComponent, AttachToEntityListener
	{
		private HashSet<string> showPrerequisites = new HashSet<string>();

		private HashSet<string> hidePrerequisites = new HashSet<string>();

		private Animator animator;

		private Animator Animator
		{
			get
			{
				if (animator == null)
				{
					animator = GetComponent<Animator>();
				}
				return animator;
			}
		}

		private bool ShouldBeHidden
		{
			get
			{
				return showPrerequisites.Count == 0 || hidePrerequisites.Count > 0;
			}
		}

		private void OnEnable()
		{
			UpdateVisibility(true);
		}

		public void AddShowPrerequisite(string prerequisite, bool instant = false)
		{
			showPrerequisites.Add(prerequisite);
			UpdateVisibility(instant);
		}

		public void RemoveShowPrerequisite(string prerequisite, bool instant = false)
		{
			showPrerequisites.Remove(prerequisite);
			UpdateVisibility(instant);
		}

		public void AddHidePrerequisite(string prerequisite, bool instant = false)
		{
			hidePrerequisites.Add(prerequisite);
			UpdateVisibility(instant);
		}

		public void RemoveHidePrerequisite(string prerequisite, bool instant = false)
		{
			hidePrerequisites.Remove(prerequisite);
			UpdateVisibility(instant);
		}

		public void RemoveAll()
		{
			showPrerequisites.Clear();
			hidePrerequisites.Clear();
		}

		private void UpdateVisibility(bool instant = false)
		{
			if (Animator.isActiveAndEnabled)
			{
				Animator.SetBool("NoAnimation", instant);
				Animator.SetBool("Visible", !ShouldBeHidden);
			}
		}

		public void AttachedToEntity(Entity entity)
		{
			GetComponent<CanvasGroup>().alpha = 0f;
			RemoveAll();
		}
	}
}
