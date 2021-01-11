using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.ECS.ClientEntitySystem.Impl;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class TutorialHideTriggerComponent : BehaviourComponent
	{
		[SerializeField]
		private float hideDelay;

		protected bool triggered;

		protected Entity tutorialStep;

		public void Activate(Entity tutorialStep)
		{
			this.tutorialStep = tutorialStep;
			base.gameObject.SetActive(true);
			if (!base.gameObject.activeInHierarchy)
			{
				ForceHide();
			}
		}

		protected virtual void Triggered()
		{
			if (!triggered)
			{
				CancelInvoke();
				triggered = true;
				if (hideDelay == 0f)
				{
					HideTutorial();
				}
				else
				{
					Invoke("HideTutorial", hideDelay);
				}
			}
		}

		private void HideTutorial()
		{
			TutorialCanvas.Instance.Hide();
			base.gameObject.SetActive(false);
		}

		public void ForceHide()
		{
			if (!triggered)
			{
				ScheduleEvent<CompleteActiveTutorialEvent>(new EntityStub());
				hideDelay = 0f;
				Triggered();
			}
		}

		private void OnDisable()
		{
			ForceHide();
		}
	}
}
