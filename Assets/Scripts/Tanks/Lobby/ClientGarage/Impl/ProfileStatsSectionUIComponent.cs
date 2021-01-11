using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientProfile.API;
using Tanks.Lobby.ClientUserProfile.Impl;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ProfileStatsSectionUIComponent : BehaviourComponent
	{
		[SerializeField]
		private RankUI rank;

		[SerializeField]
		private LeagueUIComponent league;

		public void SetRank(LevelInfo levelInfo)
		{
		}
	}
}
