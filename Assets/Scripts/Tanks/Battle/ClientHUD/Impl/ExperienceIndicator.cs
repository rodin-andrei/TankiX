using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientProfile.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class ExperienceIndicator : MonoBehaviour
	{
		[SerializeField]
		private Text expValue;

		[SerializeField]
		private Text maxExpValue;

		[SerializeField]
		private Text deltaExpValue;

		[SerializeField]
		private ColoredProgressBar progressBar;

		private long initialExp;

		private LevelInfo currentInfo = new LevelInfo(-1);

		public void Init(LevelInfo info)
		{
			initialExp = info.AbsolutExperience;
			progressBar.InitialProgress = info.Progress;
			progressBar.ColoredProgress = info.Progress;
			Set(info);
		}

		public void LevelUp()
		{
			progressBar.InitialProgress = 0f;
		}

		public void Change(LevelInfo info)
		{
			if (currentInfo != info)
			{
				Set(info);
				progressBar.ColoredProgress = info.Progress;
				currentInfo = info;
			}
		}

		private void Set(LevelInfo info)
		{
			expValue.text = info.Experience.ToStringSeparatedByThousands();
			maxExpValue.text = info.MaxExperience.ToStringSeparatedByThousands();
			long num = info.AbsolutExperience - initialExp;
			if (num > 0)
			{
				deltaExpValue.text = "+" + (info.AbsolutExperience - initialExp).ToStringSeparatedByThousands();
			}
			else
			{
				deltaExpValue.text = string.Empty;
			}
		}
	}
}
