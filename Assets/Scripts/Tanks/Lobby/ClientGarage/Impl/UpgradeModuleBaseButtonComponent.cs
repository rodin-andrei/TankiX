using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class UpgradeModuleBaseButtonComponent : BehaviourComponent
	{
		[SerializeField]
		protected TextMeshProUGUI titleText;
		[SerializeField]
		protected LocalizedField activate;
		[SerializeField]
		protected LocalizedField upgrade;
		[SerializeField]
		protected LocalizedField fullUpgraded;
		[SerializeField]
		protected Image border;
		[SerializeField]
		protected Image fill;
		[SerializeField]
		protected Color notEnoughColor;
		[SerializeField]
		protected Color notEnoughFillColor;
		[SerializeField]
		protected Color enoughColor;
		[SerializeField]
		protected Color notEnoughTextColor;
		[SerializeField]
		protected Color enoughTextColor;
		[SerializeField]
		protected GameObject notEnoughText;
		[SerializeField]
		protected LocalizedField notEnoughTextStart;
	}
}
