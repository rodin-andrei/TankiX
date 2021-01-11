using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class BattleResultsScreenStatComponent : BehaviourComponent
	{
		[SerializeField]
		private GameObject dmMatchDetails;

		[SerializeField]
		private GameObject teamMatchDetails;

		[SerializeField]
		private TextMeshProUGUI _battleDescription;

		public string BattleDescription
		{
			set
			{
				_battleDescription.text = value;
			}
		}

		private void OnDisable()
		{
			HideMatchDetails();
		}

		public void ShowDMMatchDetails()
		{
			dmMatchDetails.SetActive(true);
		}

		public void ShowTeamMatchDetails()
		{
			teamMatchDetails.SetActive(true);
		}

		public void HideMatchDetails()
		{
			dmMatchDetails.SetActive(false);
			teamMatchDetails.SetActive(false);
		}
	}
}
