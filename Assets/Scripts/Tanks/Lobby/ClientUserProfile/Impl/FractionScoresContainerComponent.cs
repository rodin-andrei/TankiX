using System.Collections.Generic;
using System.Linq;
using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class FractionScoresContainerComponent : BehaviourComponent
	{
		[SerializeField]
		private FractionScoresUiBehaviour _fractionScoresPrefab;

		[SerializeField]
		private GameObject _container;

		[SerializeField]
		private TextMeshProUGUI _cryFundText;

		private readonly Dictionary<long, FractionScoresUiBehaviour> _fractions = new Dictionary<long, FractionScoresUiBehaviour>();

		public long WinnerId
		{
			set
			{
				foreach (KeyValuePair<long, FractionScoresUiBehaviour> fraction in _fractions)
				{
					fraction.Value.IsWinner = fraction.Key == value;
				}
			}
		}

		public long TotalCryFund
		{
			set
			{
				_cryFundText.text = string.Format("{0:0}", value);
			}
		}

		public void UpdateScores(long fractionId, FractionInfoComponent info, long scores)
		{
			if (_fractions.ContainsKey(fractionId))
			{
				FractionScoresUiBehaviour fractionScoresUiBehaviour = _fractions[fractionId];
				fractionScoresUiBehaviour.FractionScores = scores;
			}
			else
			{
				FractionScoresUiBehaviour fractionScoresUiBehaviour2 = Object.Instantiate(_fractionScoresPrefab, _container.transform);
				fractionScoresUiBehaviour2.FractionName = info.FractionName;
				fractionScoresUiBehaviour2.FractionLogoUid = info.FractionLogoImageUid;
				fractionScoresUiBehaviour2.FractionColor = FractionsCompetitionUiSystem.GetColorFromHex(info.FractionColor);
				fractionScoresUiBehaviour2.FractionScores = scores;
				_fractions.Add(fractionId, fractionScoresUiBehaviour2);
			}
			List<FractionScoresUiBehaviour> list = _fractions.Values.OrderByDescending((FractionScoresUiBehaviour fraction) => fraction.FractionScores).ToList();
			for (int i = 0; i < list.Count; i++)
			{
				list[i].transform.SetSiblingIndex(i);
			}
		}
	}
}
