using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class BattleResultCommonUIComponent : UIBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		private enum ResultScreenParts
		{
			None = -1,
			BestPlayer,
			Awards,
			Stats
		}

		private ResultScreenParts currentPart;

		private bool customBattle;

		private bool spectator;

		private bool tutor;

		private bool squad;

		private bool enoughEnergy;

		public Image tankPreviewImage1;

		public Image tankPreviewImage2;

		public TopPanelButtons topPanelButtons;

		public BottomPanelButtons bottomPanelButtons;

		[SerializeField]
		private GameObject[] screenParts;

		private ResultScreenParts CurrentPart
		{
			get
			{
				return currentPart;
			}
			set
			{
				currentPart = value;
				GetComponent<Animator>().SetInteger("currentScreen", (int)value);
			}
		}

		private new void OnDisable()
		{
			CurrentPart = ResultScreenParts.None;
			GameObject[] array = screenParts;
			foreach (GameObject gameObject in array)
			{
				gameObject.SetActive(false);
			}
		}

		public void ShowTopPanel()
		{
			GetComponent<Animator>().SetBool("showTopPanel", true);
		}

		public void HideTopPanel()
		{
			GetComponent<Animator>().SetBool("showTopPanel", false);
		}

		public void ShowBottomPanel()
		{
			GetComponent<Animator>().SetBool("showBottomPanel", true);
			bottomPanelButtons.BattleSeriesResult.SetActive(!spectator && !customBattle && !tutor);
			bottomPanelButtons.TryAgainButton.SetActive(!spectator && !customBattle && !tutor && !squad && enoughEnergy);
			bottomPanelButtons.MainScreenButton.gameObject.SetActive(spectator || !customBattle);
			bottomPanelButtons.ContinueButton.gameObject.SetActive(!spectator && customBattle);
		}

		public void HideBottomPanel()
		{
			GetComponent<Animator>().SetBool("showBottomPanel", false);
		}

		public void ShowScreen(bool customBattle, bool spectator, bool tutor, bool squad, bool enoughEnergy)
		{
			this.customBattle = customBattle;
			this.spectator = spectator;
			this.tutor = tutor;
			this.squad = squad;
			this.enoughEnergy = enoughEnergy;
			if (customBattle)
			{
				ShowStats();
				return;
			}
			ShowBestPlayer();
			MVPScreenUIComponent.ShowCounter = 0;
		}

		public void ShowBestPlayer()
		{
			HideTopPanel();
			HideBottomPanel();
			CurrentPart = ResultScreenParts.BestPlayer;
			topPanelButtons.ActivateButton(0);
			MVPScreenUIComponent.ShowCounter++;
		}

		public void ContinueAfterBestPlayer()
		{
			if (spectator)
			{
				ShowStats();
				HideTopPanel();
			}
			else
			{
				ShowAwards();
			}
		}

		public void ShowAwards()
		{
			CurrentPart = ResultScreenParts.Awards;
			topPanelButtons.ActivateButton(1);
		}

		public void ShowStats()
		{
			CurrentPart = ResultScreenParts.Stats;
			ShowBottomPanel();
			if (!customBattle)
			{
				ShowTopPanel();
				topPanelButtons.ActivateButton(2);
			}
		}
	}
}
