using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class BattleResultAwardsScreenAnimationComponent : BehaviourComponent
	{
		[SerializeField]
		private Animator headerAnimator;
		[SerializeField]
		private Animator infoAnimator;
		[SerializeField]
		private Animator tankInfoAnimator;
		[SerializeField]
		private Animator specialOfferAnimator;
		[SerializeField]
		private CircleProgressBar rankProgressBar;
		[SerializeField]
		private CircleProgressBar containerProgressBar;
		[SerializeField]
		private CircleProgressBar hullProgressBar;
		[SerializeField]
		private CircleProgressBar turretProgressBar;
		public bool playActions;
	}
}
