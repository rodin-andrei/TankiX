using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class AvatarUIComponent : BehaviourComponent
	{
		[SerializeField]
		private AvatarButton avatarButtonPrefab;
		[SerializeField]
		private Transform grid;
		[SerializeField]
		private GaragePrice xPrice;
		[SerializeField]
		private GaragePrice price;
		[SerializeField]
		private Button xBuyButton;
		[SerializeField]
		private Button buyButton;
		[SerializeField]
		private Button equipButton;
		[SerializeField]
		private Button cancelButton;
		[SerializeField]
		private Button closeButton;
		[SerializeField]
		private Button toContainerButton;
		[SerializeField]
		private TMP_Text restriction;
		[SerializeField]
		private LocalizedField restrictionLocalization;
		[SerializeField]
		private LocalizedField avatarTypeLocalization;
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
