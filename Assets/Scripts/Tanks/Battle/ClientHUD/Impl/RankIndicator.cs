using Tanks.Battle.ClientHUD.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class RankIndicator : AnimatedIndicatorWithFinishComponent<PersonalBattleResultRankIndicatorFinishedComponent>
	{
		[SerializeField]
		private ImageListSkin currentLevel;
		[SerializeField]
		private ImageListSkin nextLevel;
		[SerializeField]
		private ExperienceIndicator exp;
	}
}
