using Tanks.Lobby.ClientControls.API;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class SummaryBonusComponent : LocalizedControl
	{
		[SerializeField]
		private List<StaticBonusUI> bonuses;
		[SerializeField]
		private Text totalBonusText;
	}
}
