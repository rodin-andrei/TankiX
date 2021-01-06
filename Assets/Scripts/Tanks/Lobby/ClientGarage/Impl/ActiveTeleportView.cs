using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ActiveTeleportView : MonoBehaviour
	{
		public Image fill;
		public TextMeshProUGUI text;
		public MultipleBonusView cryBonusView;
		public MultipleBonusView xCryBonusView;
		public MultipleBonusView energyBonusView;
		public ContainerBonusView containerBonusView;
		public DetailBonusView detailBonusView;
	}
}
