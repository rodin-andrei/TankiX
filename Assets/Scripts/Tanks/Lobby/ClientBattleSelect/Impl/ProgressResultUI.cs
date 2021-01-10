using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using TMPro;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class ProgressResultUI : MonoBehaviour
	{
		[SerializeField]
		private AnimatedDiffRadialProgress experienceProgress;
		[SerializeField]
		protected TextMeshProUGUI expRewardUI;
		[SerializeField]
		private Animator animator;
	}
}
