using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class LevelIndicator<T> : AnimatedIndicatorWithFinishComponent<T>
	{
		[SerializeField]
		private ColoredProgressBar levelProgress;
		[SerializeField]
		private Text levelValue;
		[SerializeField]
		private Text deltaLevelValue;
		[SerializeField]
		private ExperienceIndicator exp;
	}
}
