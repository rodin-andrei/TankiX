using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using TMPro;
using System.Collections.Generic;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ItemUnlockUIComponent : MonoBehaviour
	{
		public AnimatedProgress experienceProgressBar;
		public TextMeshProUGUI text;
		public GameObject rewardPrefab;
		public GameObject rewardContainer;
		public List<GameObject> rewardPreviews;
		public LocalizedField recievedText;
		public LocalizedField levelText;
		public LocalizedField maxText;
	}
}
