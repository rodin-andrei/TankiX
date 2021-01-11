using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class RankedBattleGUIComponent : BehaviourComponent
	{
		[SerializeField]
		private ImageSkin leagueIcon;

		[SerializeField]
		private TextMeshProUGUI leagueName;

		[SerializeField]
		private LocalizedField costTextLocalization;

		public void SetLeague(string name, string icon)
		{
			leagueName.text = name;
			leagueIcon.SpriteUid = icon;
		}

		public void Click()
		{
			GetComponent<Button>().onClick.Invoke();
		}
	}
}
