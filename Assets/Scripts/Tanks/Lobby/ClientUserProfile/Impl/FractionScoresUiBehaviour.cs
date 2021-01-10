using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using TMPro;

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
		[SerializeField]
		private GameObject _winnerMark;
	}
}
