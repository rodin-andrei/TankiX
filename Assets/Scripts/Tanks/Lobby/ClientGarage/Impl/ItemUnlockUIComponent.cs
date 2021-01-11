using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ItemUnlockUIComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public AnimatedProgress experienceProgressBar;

		public TextMeshProUGUI text;

		public GameObject rewardPrefab;

		public GameObject rewardContainer;

		public List<GameObject> rewardPreviews = new List<GameObject>();

		public LocalizedField recievedText;

		public LocalizedField levelText;

		public LocalizedField maxText;
	}
}
