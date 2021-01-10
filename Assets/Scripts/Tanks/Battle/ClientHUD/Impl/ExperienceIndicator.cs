using UnityEngine;
using UnityEngine.UI;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class ExperienceIndicator : MonoBehaviour
	{
		[SerializeField]
		private Text expValue;
		[SerializeField]
		private Text maxExpValue;
		[SerializeField]
		private Text deltaExpValue;
		[SerializeField]
		private ColoredProgressBar progressBar;
	}
}
