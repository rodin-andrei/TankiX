using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientProfile.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class LevelIndicator<T> : AnimatedIndicatorWithFinishComponent<T> where T : Platform.Kernel.ECS.ClientEntitySystem.API.Component, new()
	{
		[SerializeField]
		private ColoredProgressBar levelProgress;

		[SerializeField]
		private Text levelValue;

		[SerializeField]
		private Text deltaLevelValue;

		[SerializeField]
		private ExperienceIndicator exp;

		private long fromExp;

		private long toExp;

		private NormalizedAnimatedValue animation;

		private int level;

		private int initialLevel;

		private int[] levels;

		private void Awake()
		{
			animation = GetComponent<NormalizedAnimatedValue>();
		}

		public void Init(Entity screenEntity, long fromExp, long toExp, int[] levels)
		{
			SetEntity(screenEntity);
			LevelInfo info = LevelInfo.Get(fromExp, levels);
			if (info.IsMaxLevel)
			{
				base.gameObject.SetActive(false);
				return;
			}
			base.gameObject.SetActive(true);
			level = info.Level;
			this.levels = levels;
			this.fromExp = fromExp;
			this.toExp = toExp;
			initialLevel = info.Level;
			exp.Init(info);
			levelProgress.InitialProgress = (float)info.Level / (float)levels.Length;
			levelProgress.ColoredProgress = levelProgress.InitialProgress;
			levelValue.text = info.Level.ToString();
			GetComponent<Animator>().SetTrigger("Start");
			deltaLevelValue.gameObject.SetActive(false);
		}

		public void Update()
		{
			float num = animation.value * (float)(toExp - fromExp);
			LevelInfo info = LevelInfo.Get(fromExp + (long)num, levels);
			if (info.Level != level)
			{
				GetComponent<Animator>().SetTrigger("Up");
				levelValue.text = info.Level.ToString();
				exp.LevelUp();
				levelProgress.ColoredProgress = (float)info.Level / (float)levels.Length;
				level = info.Level;
				deltaLevelValue.gameObject.SetActive(true);
				deltaLevelValue.text = "+" + (info.Level - initialLevel);
			}
			info.ClampExp();
			exp.Change(info);
			TryToSetAnimationFinished(info.AbsolutExperience, toExp);
		}
	}
}
