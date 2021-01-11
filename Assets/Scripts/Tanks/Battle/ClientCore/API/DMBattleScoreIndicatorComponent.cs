using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Battle.ClientCore.API
{
	public class DMBattleScoreIndicatorComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		private const string VISIBLE_ANIMATION_PROP = "Visible";

		private const string INITIALLY_VISIBLE_ANIMATION_PROP = "InitiallyVisible";

		private const string BLINK_ANIMATION_PROP = "Blink";

		private const string NO_ANIMATION_PROP = "NoAnimation";

		private int score;

		private int scoreLimit;

		private bool limitVisible;

		private ProgressBar progressBar;

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

		public int Score
		{
			get
			{
				return score;
			}
			set
			{
				score = value;
				scoreText.text = value.ToString();
			}
		}

		public int ScoreLimit
		{
			get
			{
				return scoreLimit;
			}
			set
			{
				scoreLimit = value;
				scoreLimitText.text = value.ToString();
			}
		}

		public float ProgressValue
		{
			get
			{
				return ProgressBar().ProgressValue;
			}
			set
			{
				ProgressBar().ProgressValue = value;
			}
		}

		public bool LimitVisible
		{
			get
			{
				return limitVisible;
			}
			set
			{
				limitVisible = value;
				scoreLimitText.GetComponent<Animator>().SetBool("Visible", value);
			}
		}

		public void Awake()
		{
			Score = 0;
			ScoreLimit = 0;
		}

		public void OnEnable()
		{
			propagateAnimationParam("Visible", normallyVisible);
			propagateAnimationParam("InitiallyVisible", normallyVisible);
			propagateAnimationParam("NoAnimation", noAnimation);
		}

		public void BlinkIcon()
		{
			iconAnimator.SetTrigger("Blink");
		}

		private void propagateAnimationParam(string paramName, bool paramValue)
		{
			scoreLimitText.GetComponent<Animator>().SetBool(paramName, paramValue);
		}

		private ProgressBar ProgressBar()
		{
			if (progressBar == null)
			{
				progressBar = GetComponent<ProgressBar>();
			}
			return progressBar;
		}
	}
}
