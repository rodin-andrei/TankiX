using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class MainVisualPropertyUI : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI text;

		[SerializeField]
		private AnimatedProgress progress;

		public void Set(string name, float progress)
		{
			this.progress.NormalizedValue = progress;
			text.text = name;
		}
	}
}
