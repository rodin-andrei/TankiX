using System;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class LeagueUIComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI leagueName;

		[SerializeField]
		private ImageSkin leagueIcon;

		[SerializeField]
		private TextMeshProUGUI leaguePoints;

		[SerializeField]
		private LocalizedField pointsLocalizedField;

		public void SetLeague(string name, string icon, double points)
		{
			leagueName.text = name;
			leaguePoints.text = pointsLocalizedField.Value + "\n" + Math.Truncate(points);
			leagueIcon.SpriteUid = icon;
		}
	}
}
