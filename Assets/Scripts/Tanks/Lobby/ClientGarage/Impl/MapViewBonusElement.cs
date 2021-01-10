using UnityEngine;
using UnityEngine.UI;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class MapViewBonusElement : MonoBehaviour
	{
		[SerializeField]
		private GameObject inaccesible;
		[SerializeField]
		private Toggle accesible;
		[SerializeField]
		private Toggle epicAccesible;
		[SerializeField]
		private GameObject taken;
		[SerializeField]
		private GameObject epicTaken;
		[SerializeField]
		private LocalizedField crystalText;
		[SerializeField]
		private LocalizedField xCrystalText;
		[SerializeField]
		private LocalizedField chargesText;
		[SerializeField]
		private LocalizedField hiddenText;
	}
}
