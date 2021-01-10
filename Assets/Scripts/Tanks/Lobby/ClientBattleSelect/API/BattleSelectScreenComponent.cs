using UnityEngine;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientBattleSelect.API
{
	public class BattleSelectScreenComponent : MonoBehaviour
	{
		[SerializeField]
		private EntityBehaviour itemContentPrefab;
		[SerializeField]
		private GameObject prevBattlesButton;
		[SerializeField]
		private GameObject nextBattlesButton;
		[SerializeField]
		private GameObject enterBattleDMButton;
		[SerializeField]
		private GameObject enterBattleRedButton;
		[SerializeField]
		private GameObject enterBattleBlueButton;
		[SerializeField]
		private GameObject enterAsSpectatorButton;
		[SerializeField]
		private RectTransform battleInfoPanelsContainer;
		[SerializeField]
		private GameObject dmInfoPanel;
		[SerializeField]
		private GameObject tdmInfoPanel;
		[SerializeField]
		private GameObject entrancePanel;
		[SerializeField]
		private GameObject friendsPanel;
		[SerializeField]
		private Text enterBattleDMButtonText;
		[SerializeField]
		private Text enterBattleRedButtonText;
		[SerializeField]
		private Text enterBattleBlueButtonText;
		[SerializeField]
		private Text enterAsSpectatorButtonText;
	}
}
