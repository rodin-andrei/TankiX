using Tanks.Lobby.ClientNavigation.API;
using UnityEngine.UI;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class DMBattleResultsScreenComponent : LocalizedScreenComponent
	{
		[SerializeField]
		private Text selfScore;
		[SerializeField]
		private Text maxScore;
		[SerializeField]
		private ProgressBar progressBar;
		[SerializeField]
		private Text mapName;
	}
}
