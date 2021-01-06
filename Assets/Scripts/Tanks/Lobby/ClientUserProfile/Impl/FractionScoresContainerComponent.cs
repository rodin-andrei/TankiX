using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using TMPro;

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
	}
}
