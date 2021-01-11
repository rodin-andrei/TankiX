using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientGarage.Impl;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.API
{
	public class ContainerComponent : BehaviourComponent, AttachToEntityListener, DetachFromEntityListener
	{
		private Entity entity;

		[SerializeField]
		private Animator containerAnimator;

		[SerializeField]
		private ParticleSystem[] dustParticles;

		[SerializeField]
		private AudioSource openSound;

		[SerializeField]
		private AudioSource closeSound;

		[SerializeField]
		private string idleClosedAnimationName;

		[SerializeField]
		private string closingAnimationName;

		public string assetGuid
		{
			get;
			set;
		}

		public void ShowOpenContainerAnimation()
		{
			PlayDustAnimators();
			openSound.Play();
			closeSound.Stop();
			containerAnimator.ResetTrigger("open");
			containerAnimator.SetTrigger("open");
		}

		public void ContainerOpend()
		{
			ScheduleEvent(new OpenContainerAnimationShownEvent(), entity);
		}

		public void PlayDustAnimators()
		{
			ParticleSystem[] array = dustParticles;
			foreach (ParticleSystem particleSystem in array)
			{
				particleSystem.Play();
			}
		}

		public void CloseContainer()
		{
			if (!InClosingState())
			{
				openSound.Stop();
				closeSound.Play();
				containerAnimator.ResetTrigger("close");
				containerAnimator.SetTrigger("close");
			}
		}

		private bool InClosingState()
		{
			return containerAnimator.GetCurrentAnimatorStateInfo(0).IsName(idleClosedAnimationName) || containerAnimator.GetCurrentAnimatorStateInfo(0).IsName(closingAnimationName);
		}

		void AttachToEntityListener.AttachedToEntity(Entity entity)
		{
			this.entity = entity;
		}

		void DetachFromEntityListener.DetachedFromEntity(Entity entity)
		{
			this.entity = null;
		}
	}
}
