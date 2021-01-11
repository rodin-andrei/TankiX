using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class FractionScoresUiBehaviour : MonoBehaviour
	{
		[SerializeField]
		private ImageSkin _fractionLogo;

		[SerializeField]
		private TextMeshProUGUI _fractionName;

		[SerializeField]
		private TextMeshProUGUI _fractionScores;

		private long _scores;

		[SerializeField]
		private GameObject _winnerMark;

		public string FractionLogoUid
		{
			set
			{
				_fractionLogo.SpriteUid = value;
			}
		}

		public string FractionName
		{
			set
			{
				_fractionName.text = value;
			}
		}

		public Color FractionColor
		{
			set
			{
				_fractionName.color = value;
			}
		}

		public long FractionScores
		{
			get
			{
				return _scores;
			}
			set
			{
				_fractionScores.text = value.ToString();
				_scores = value;
			}
		}

		public bool IsWinner
		{
			set
			{
				_winnerMark.SetActive(value);
			}
		}
	}
}
