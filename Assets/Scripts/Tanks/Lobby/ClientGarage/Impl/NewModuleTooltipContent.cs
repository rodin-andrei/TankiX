using UnityEngine;
using tanks.modules.lobby.ClientControls.Scripts.API;
using TMPro;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class NewModuleTooltipContent : MonoBehaviour
	{
		public ComplexFillProgressBar progressBar;
		public TextMeshProUGUI nameAndLevel;
		public TextMeshProUGUI definition;
		public LocalizedField levelPrefix;
		public TextMeshProUGUI blueprints;
	}
}
