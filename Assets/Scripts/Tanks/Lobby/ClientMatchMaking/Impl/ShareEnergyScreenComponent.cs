using Platform.Kernel.ECS.ClientEntitySystem.Impl;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientGarage.Impl;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientMatchMaking.Impl
{
	public class ShareEnergyScreenComponent : BehaviourComponent
	{
		[SerializeField]
		private Button startButton;

		[SerializeField]
		private Button exitButton;

		[SerializeField]
		private Button hideButton;

		[SerializeField]
		private TextMeshProUGUI readyPlayers;

		[SerializeField]
		private LocalizedField notAllPlayersReady;

		[SerializeField]
		private LocalizedField allPlayersReady;

		[SerializeField]
		private CircleProgressBar teleportPriceProgressBar;

		public CircleProgressBar TeleportPriceProgressBar
		{
			get
			{
				return teleportPriceProgressBar;
			}
		}

		public bool SelfPlayerIsSquadLeader
		{
			set
			{
				startButton.gameObject.SetActive(value);
				exitButton.gameObject.SetActive(value);
				hideButton.gameObject.SetActive(!value);
			}
		}

		private void OnEnable()
		{
			hideButton.onClick.AddListener(MainScreenComponent.Instance.HideShareEnergyScreen);
		}

		private void OnDisable()
		{
			hideButton.onClick.RemoveListener(MainScreenComponent.Instance.HideShareEnergyScreen);
		}

		public void ReadyPlayers(int ready, int allPlayers)
		{
			bool flag = allPlayers == ready;
			readyPlayers.text = ((!flag) ? string.Format(notAllPlayersReady, ready, allPlayers) : allPlayersReady.Value);
		}

		public void BackClick(BaseEventData data)
		{
			ScheduleEvent<HideAllShareButtonsEvent>(new EntityStub());
		}
	}
}
