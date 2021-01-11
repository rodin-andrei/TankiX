using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientBattleSelect.API
{
	[SerialVersionUID(635824351093325226L)]
	public class BattleSelectScreenComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
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

		public Text EnterAsSpectatorButtonText
		{
			get
			{
				return enterAsSpectatorButtonText;
			}
		}

		public Text EnterBattleBlueButtonText
		{
			get
			{
				return enterBattleBlueButtonText;
			}
		}

		public Text EnterBattleRedButtonText
		{
			get
			{
				return enterBattleRedButtonText;
			}
		}

		public Text EnterBattleDmButtonText
		{
			get
			{
				return enterBattleDMButtonText;
			}
		}

		public EntityBehaviour ItemContentPrefab
		{
			get
			{
				return itemContentPrefab;
			}
		}

		public GameObject PrevBattlesButton
		{
			get
			{
				return prevBattlesButton;
			}
		}

		public GameObject NextBattlesButton
		{
			get
			{
				return nextBattlesButton;
			}
		}

		public GameObject EnterBattleDMButton
		{
			get
			{
				return enterBattleDMButton;
			}
		}

		public GameObject EnterBattleRedButton
		{
			get
			{
				return enterBattleRedButton;
			}
		}

		public GameObject EnterBattleBlueButton
		{
			get
			{
				return enterBattleBlueButton;
			}
		}

		public GameObject EnterBattleAsSpectatorButton
		{
			get
			{
				return enterAsSpectatorButton;
			}
		}

		public RectTransform BattleInfoPanelsContainer
		{
			get
			{
				return battleInfoPanelsContainer;
			}
		}

		public GameObject DMInfoPanel
		{
			get
			{
				return dmInfoPanel;
			}
		}

		public GameObject TDMInfoPanel
		{
			get
			{
				return tdmInfoPanel;
			}
		}

		public GameObject EntrancePanel
		{
			get
			{
				return entrancePanel;
			}
		}

		public GameObject FriendsPanel
		{
			get
			{
				return friendsPanel;
			}
		}

		public bool DebugEnabled
		{
			get;
			set;
		}

		private void Awake()
		{
			DMInfoPanel.SetActive(false);
			TDMInfoPanel.SetActive(false);
		}
	}
}
