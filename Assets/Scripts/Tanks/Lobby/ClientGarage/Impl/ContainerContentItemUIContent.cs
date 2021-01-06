using UnityEngine;
using TMPro;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ContainerContentItemUIContent : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _name;
		[SerializeField]
		private GameObject _own;
		[SerializeField]
		private ImageSkin _preview;
		[SerializeField]
		private LocalizedField _commonString;
		[SerializeField]
		private LocalizedField _rareString;
		[SerializeField]
		private LocalizedField _epicString;
		[SerializeField]
		private LocalizedField _legendaryString;
	}
}
