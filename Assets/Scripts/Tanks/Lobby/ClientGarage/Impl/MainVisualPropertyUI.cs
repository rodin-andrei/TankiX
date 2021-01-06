using UnityEngine;
using TMPro;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class MainVisualPropertyUI : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI text;
		[SerializeField]
		private AnimatedProgress progress;
	}
}
