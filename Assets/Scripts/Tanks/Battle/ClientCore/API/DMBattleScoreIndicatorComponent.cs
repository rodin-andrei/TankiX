using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Battle.ClientCore.API
{
	public class DMBattleScoreIndicatorComponent : MonoBehaviour
	{
		[SerializeField]
		private Text scoreText;
		[SerializeField]
		private Text scoreLimitText;
		[SerializeField]
		private Animator iconAnimator;
		[SerializeField]
		private bool normallyVisible;
		[SerializeField]
		private bool noAnimation;
	}
}
