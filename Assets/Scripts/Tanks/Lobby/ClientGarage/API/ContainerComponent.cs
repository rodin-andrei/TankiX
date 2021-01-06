using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.API
{
	public class ContainerComponent : BehaviourComponent
	{
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
	}
}
