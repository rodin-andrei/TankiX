using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class UpgradePropertyUI : MonoBehaviour
	{
		[SerializeField]
		protected TextMeshProUGUI valueLabel;
		[SerializeField]
		protected TextMeshProUGUI nextValueLabel;
		[SerializeField]
		protected new TextMeshProUGUI name;
		[SerializeField]
		protected GameObject arrow;
	}
}
