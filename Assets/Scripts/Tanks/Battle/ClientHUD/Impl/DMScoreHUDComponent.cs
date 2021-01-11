using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class DMScoreHUDComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI place;

		[SerializeField]
		private TextMeshProUGUI playerScore;

		private int _place;

		private int _players;

		private int _playerScore;

		private int _maxScore;

		public int Place
		{
			get
			{
				return _place;
			}
			set
			{
				_place = value;
				UpdatePlayerPlace();
			}
		}

		public int Players
		{
			get
			{
				return _players;
			}
			set
			{
				_players = value;
				UpdatePlayerPlace();
			}
		}

		public int PlayerScore
		{
			get
			{
				return _playerScore;
			}
			set
			{
				_playerScore = value;
				UpdatePlayerScore();
			}
		}

		public int MaxScore
		{
			get
			{
				return _maxScore;
			}
			set
			{
				_maxScore = value;
				UpdatePlayerScore();
			}
		}

		public void UpdatePlayerPlace()
		{
			place.text = string.Format("{0}<size=12>/{1}</size>", _place, _players);
		}

		public void UpdatePlayerScore()
		{
			playerScore.text = string.Format("{0}<size=12>/{1}</size>", _playerScore, _maxScore);
		}

		private void OnDisable()
		{
			base.gameObject.SetActive(false);
		}
	}
}
