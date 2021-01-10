using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using TMPro;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ContainerContentUI : MonoBehaviour
	{
		[SerializeField]
		private DefaultListDataProvider dataProvider;
		[SerializeField]
		private Animator contentAnimator;
		[SerializeField]
		private GameObject graffitiRoot;
		[SerializeField]
		private TextMeshProUGUI containerDescription;
	}
}
