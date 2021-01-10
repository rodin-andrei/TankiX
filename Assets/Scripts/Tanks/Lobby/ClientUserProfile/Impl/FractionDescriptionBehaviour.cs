using UnityEngine;
using TMPro;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class FractionDescriptionBehaviour : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _fractionTitle;
		[SerializeField]
		private TextMeshProUGUI _fractionSlogan;
		[SerializeField]
		private TextMeshProUGUI _fractionDescription;
		[SerializeField]
		private ImageSkin _fractionLogo;
		[SerializeField]
		private FractionButtonComponent[] _fractionButtons;
	}
}
