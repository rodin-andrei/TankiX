using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;

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

		public void SetupTutorialReward(long crys, string itemSpriteUID)
		{
			crysCount.text = crysLocalizedField.Value + " x" + crys;
			itemName.text = itemLocalizedField.Value;
			item.SpriteUid = itemSpriteUID;
		}
	}
}
