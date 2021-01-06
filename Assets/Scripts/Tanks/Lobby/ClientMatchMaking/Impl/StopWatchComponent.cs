using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientMatchMaking.Impl
{
	public class StopWatchComponent : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI textLabel;
		public bool isOn;
	}
}
