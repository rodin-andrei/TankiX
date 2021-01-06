using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class MostPlayedEquipmentUIComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI turretIcon;
		[SerializeField]
		private TextMeshProUGUI turretLabel;
		[SerializeField]
		private TextMeshProUGUI hullIcon;
		[SerializeField]
		private TextMeshProUGUI hullLabel;
		[SerializeField]
		private GameObject content;
	}
}
