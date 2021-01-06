using UnityEngine;
using TMPro;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class TutorialRewardsUIComponent : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI crysCount;
		[SerializeField]
		private TextMeshProUGUI itemName;
		[SerializeField]
		private ImageSkin item;
		[SerializeField]
		private LocalizedField crysLocalizedField;
		[SerializeField]
		private LocalizedField itemLocalizedField;
	}
}
