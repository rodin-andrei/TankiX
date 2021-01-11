using System;
using System.Collections.Generic;
using log4net;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.ECS.ClientEntitySystem.Impl;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientLogger.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientGarage.API;
using Tanks.Lobby.ClientNavigation.API;
using Tanks.Lobby.ClientQuests.Impl;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class MainScreenComponent : BehaviourComponent, NoScaleScreen
	{
		public interface IPanelShowListener
		{
			void OnPanelShow(MainScreens screen);
		}

		public enum MainScreens
		{
			CustomBattleScreen = -21,
			PlayScreen = -20,
			UserProfile = -5,
			MatchLobby = -4,
			MatchSearching = -3,
			GameMode = -2,
			Main = -1,
			Parts = 0,
			HullsAndTurrets = 1,
			Customization = 2,
			Shop = 3,
			CreateBattle = 4,
			Cards = 5,
			StarterPack = 6,
			ShareEnergyScreen = 7,
			TankRent = 8,
			Hide = 99
		}

		public class HistoryItem
		{
			public string Key;

			public Action Action;

			public Action OnBackToThis;

			public Action OnGoFromThis;

			public Action OnBackFromThis;
		}

		private int cardsCount;

		private int notificationsCount;

		private static MainScreenComponent instance;

		private readonly HashSet<IPanelShowListener> panelListeners = new HashSet<IPanelShowListener>();

		[SerializeField]
		private ItemSelectUI itemSelect;

		[SerializeField]
		private GameObject backButton;

		[SerializeField]
		private TextMeshProUGUI modeTitleInSearchingScreen;

		[SerializeField]
		private GameObject deserterIcon;

		[SerializeField]
		private DeserterDescriptionUIComponent deserterDesc;

		[SerializeField]
		private LocalizedField deserterDescLocalized;

		[SerializeField]
		private LocalizedField battlesDef;

		[SerializeField]
		private LocalizedField battlesOne;

		[SerializeField]
		private LocalizedField battlesTwo;

		[SerializeField]
		private GameObject starterPackButton;

		[SerializeField]
		private GameObject starterPackScreen;

		[SerializeField]
		private GameObject questsBtn;

		[SerializeField]
		private GameObject dailyBonusBtn;

		private Stack<HistoryItem> history = new Stack<HistoryItem>();

		private HistoryItem currentlyShown;

		private bool currentlyShownAddToHistory;

		private Action onBackOverride;

		private bool locked;

		public GameObject playButton;

		private Animator animator;

		private MainScreens lastPanel = MainScreens.Main;

		public Entity lastSelectedGameModeId;

		private ILog log = LoggerProvider.GetLogger<MainScreenComponent>();

		private IDictionary<string, Animator> animators = new Dictionary<string, Animator>();

		private bool noReset;

		[Inject]
		public new static EngineServiceInternal EngineService
		{
			get;
			set;
		}

		[Inject]
		public static NodeDescriptionRegistry NodeDescriptionRegistry
		{
			get;
			set;
		}

		[Inject]
		public static GarageItemsRegistry GarageItemsRegistry
		{
			get;
			set;
		}

		public int CardsCount
		{
			get
			{
				return cardsCount;
			}
			set
			{
				cardsCount = value;
			}
		}

		public int NotificationsCount
		{
			get
			{
				return notificationsCount;
			}
			set
			{
				notificationsCount = value;
			}
		}

		public static MainScreenComponent Instance
		{
			get
			{
				return instance;
			}
		}

		public GameObject StarterPackButton
		{
			get
			{
				return starterPackButton;
			}
		}

		public GameObject StarterPackScreen
		{
			get
			{
				return starterPackScreen;
			}
		}

		public GameObject QuestsBtn
		{
			get
			{
				return questsBtn;
			}
		}

		public GameObject DailyBonusBtn
		{
			get
			{
				return dailyBonusBtn;
			}
		}

		public TankPartItem MountedHull
		{
			get;
			set;
		}

		public TankPartItem MountedTurret
		{
			get;
			set;
		}

		public Action OnBack
		{
			get
			{
				return onBackOverride;
			}
		}

		private void Awake()
		{
			animator = GetComponent<Animator>();
			instance = this;
		}

		private void OnGUI()
		{
			if (UnityEngine.Event.current.isMouse)
			{
				this.SendEvent<HangarCameraDelayAutoRotateEvent>();
			}
		}

		private void OnEnable()
		{
			SetPanel(lastPanel);
			if (!animator.enabled)
			{
				animator.enabled = true;
				GetComponent<CanvasGroup>().alpha = 1f;
			}
		}

		public void ShowScreen(MainScreens screen, bool addToHistory = true)
		{
			if (addToHistory)
			{
				HistoryItem historyItem = new HistoryItem();
				historyItem.Key = screen.ToString();
				historyItem.Action = delegate
				{
					SetPanel(screen);
				};
				HistoryItem item = historyItem;
				ShowHistoryItem(item);
			}
			else
			{
				SetPanel(screen);
				UpdateBackButton();
			}
		}

		public void AddListener(IPanelShowListener listener)
		{
			if (!panelListeners.Contains(listener))
			{
				panelListeners.Add(listener);
			}
		}

		public void OnPanelShow(MainScreens screen)
		{
			foreach (IPanelShowListener panelListener in panelListeners)
			{
				panelListener.OnPanelShow(screen);
			}
		}

		public void RegisterScreen(string screenName, Animator screenAnimator)
		{
			animators[screenName] = screenAnimator;
		}

		public void ShowScreen(string screenName, bool addToHistory = true)
		{
			Animator screenAnimator;
			if (!animators.TryGetValue(screenName, out screenAnimator))
			{
				throw new Exception("Screen not registered: " + screenName);
			}
			ShowHistoryItem(new HistoryItem
			{
				Key = screenName,
				Action = delegate
				{
					SetPanel(MainScreens.Hide);
					screenAnimator.gameObject.SetActive(true);
					screenAnimator.SetBool("show", true);
				},
				OnGoFromThis = delegate
				{
					screenAnimator.SetBool("show", false);
				}
			}, addToHistory);
		}

		private void UpdateBackButton()
		{
			MainScreens currentPanel = GetCurrentPanel();
			if (currentPanel == MainScreens.Main || currentPanel == MainScreens.Shop)
			{
				backButton.SetActive(false);
			}
			else
			{
				backButton.SetActive(HasHistory());
			}
		}

		public bool HasHistory()
		{
			return history.Count != 0;
		}

		private bool IsCurrentScreenInHistory()
		{
			bool result = true;
			if (Enum.IsDefined(typeof(MainScreens), currentlyShown.Key))
			{
				MainScreens mainScreens = (MainScreens)Enum.Parse(typeof(MainScreens), currentlyShown.Key);
				if (GetCurrentPanel() != mainScreens)
				{
					result = false;
				}
			}
			return result;
		}

		public void ShowOrHideScreen(MainScreens screen, bool addToHistory = true)
		{
			if (GetCurrentPanel() == screen)
			{
				ShowMain();
			}
			else
			{
				ShowScreen(screen, addToHistory);
			}
		}

		public void ShowHistoryItem(HistoryItem item, bool addToHistory = true)
		{
			if (currentlyShown != null && currentlyShown.Key != item.Key)
			{
				if (currentlyShown.OnGoFromThis != null)
				{
					currentlyShown.OnGoFromThis();
				}
				if (currentlyShownAddToHistory)
				{
					history.Push(currentlyShown);
				}
			}
			bool flag = false;
			foreach (HistoryItem item2 in history)
			{
				if (item2.Key == item.Key)
				{
					flag = true;
				}
			}
			if (flag)
			{
				while (history.Pop().Key != item.Key)
				{
				}
			}
			log.InfoFormat("Show {0}", item.Key);
			currentlyShown = item;
			currentlyShownAddToHistory = addToHistory;
			currentlyShown.Action();
			UpdateBackButton();
		}

		public void SetOnBackCallback(Action callback)
		{
			currentlyShown.OnBackToThis = callback;
		}

		public void GoBack()
		{
			if (onBackOverride != null)
			{
				onBackOverride();
			}
			else
			{
				if (locked)
				{
					return;
				}
				if (!IsCurrentScreenInHistory())
				{
					ShowLast();
					return;
				}
				if (currentlyShown.OnGoFromThis != null)
				{
					currentlyShown.OnGoFromThis();
				}
				if (currentlyShown.OnBackFromThis != null)
				{
					currentlyShown.OnBackFromThis();
				}
				currentlyShown = history.Pop();
				if (currentlyShown.OnBackToThis != null)
				{
					currentlyShown.OnBackToThis();
				}
				currentlyShown.Action();
				UpdateBackButton();
			}
		}

		public void ShowMain()
		{
			HistoryItem historyItem = new HistoryItem();
			historyItem.Key = "Main";
			historyItem.Action = delegate
			{
				this.SendEvent<ResetPreviewEvent>();
				SetPanel(MainScreens.Main);
			};
			HistoryItem item = historyItem;
			ShowHistoryItem(item);
		}

		public void ShowShop()
		{
			Animator component = GetComponent<Animator>();
			if (component.GetInteger("ShowPanel") == 3)
			{
				ShowMain();
			}
			else
			{
				ShowShopIfNotVisible();
			}
		}

		public void ShowCardsNotification(bool cards)
		{
			Animator component = GetComponent<Animator>();
			component.SetBool("Cards", cards);
			OnPanelShow(MainScreens.Cards);
		}

		public void HideNewItemNotification()
		{
			if (cardsCount < 0 || notificationsCount < 0)
			{
				cardsCount = 0;
				notificationsCount = 0;
			}
			if (cardsCount == 0 && notificationsCount == 0)
			{
				animator.SetBool("Cards", false);
			}
			OnPanelShow(GetCurrentPanel());
		}

		public void ShowShopIfNotVisible()
		{
			Animator component = GetComponent<Animator>();
			HistoryItem historyItem = new HistoryItem();
			historyItem.Key = "Shop";
			historyItem.Action = delegate
			{
				SetPanel(MainScreens.Shop);
			};
			HistoryItem item = historyItem;
			ShowHistoryItem(item);
		}

		public void HideQuestsIfVisible()
		{
			QuestWindowComponent questWindowComponent = UnityEngine.Object.FindObjectOfType<Dialogs60Component>().Get<QuestWindowComponent>();
			if (questWindowComponent.gameObject.activeSelf)
			{
				questWindowComponent.HideWindow();
			}
		}

		public void ShowLast()
		{
			if (currentlyShown != null)
			{
				if (currentlyShown.OnBackToThis != null)
				{
					currentlyShown.OnBackToThis();
				}
				currentlyShown.Action();
				UpdateBackButton();
			}
			else
			{
				ShowMain();
			}
		}

		public void ClearHistory()
		{
			currentlyShown = null;
			history.Clear();
		}

		public void ShowParts()
		{
			MainScreens currentPanel = GetCurrentPanel();
			if (currentPanel == MainScreens.HullsAndTurrets || currentPanel == MainScreens.Customization || currentPanel == MainScreens.Parts)
			{
				ShowMain();
				return;
			}
			HistoryItem historyItem = new HistoryItem();
			historyItem.Key = "ShowParts";
			historyItem.Action = delegate
			{
				if (noReset)
				{
					noReset = false;
				}
				else
				{
					this.SendEvent<ResetPreviewEvent>();
				}
				SetPanel(MainScreens.Parts);
			};
			HistoryItem item = historyItem;
			ShowHistoryItem(item);
		}

		public void DisableReset()
		{
			noReset = true;
		}

		public void ShowHulls()
		{
			ShowHulls(MountedHull);
		}

		public void ShowHulls(TankPartItem selected)
		{
			HistoryItem historyItem = new HistoryItem();
			historyItem.Key = "ShowHulls";
			historyItem.OnBackFromThis = delegate
			{
				if (!itemSelect.IsSelected)
				{
					selected.Select();
				}
			};
			historyItem.Action = delegate
			{
				SendShowScreenStat(LogScreen.Hulls);
				SetPanel(MainScreens.HullsAndTurrets);
				itemSelect.SetItems(GarageItemsRegistry.Hulls, selected);
			};
			HistoryItem item = historyItem;
			ShowHistoryItem(item);
		}

		public void ShowTurrets()
		{
			ShowTurrets(MountedTurret);
		}

		public void ShowTurrets(TankPartItem selected)
		{
			HistoryItem historyItem = new HistoryItem();
			historyItem.Key = "ShowTurrets";
			historyItem.OnBackFromThis = delegate
			{
				if (!itemSelect.IsSelected)
				{
					selected.Select();
				}
			};
			historyItem.Action = delegate
			{
				SendShowScreenStat(LogScreen.Turrets);
				SetPanel(MainScreens.HullsAndTurrets);
				itemSelect.SetItems(GarageItemsRegistry.Turrets, selected);
			};
			HistoryItem item = historyItem;
			ShowHistoryItem(item);
		}

		public void ShowStarterPack()
		{
			ShowScreen(MainScreens.StarterPack, false);
			backButton.SetActive(false);
		}

		public void ShowCustomization()
		{
			ShowScreen(MainScreens.Customization, false);
		}

		public void ShowCustomBattleScreen()
		{
			ShowScreen(MainScreens.CustomBattleScreen);
		}

		public void ShowPlayScreen()
		{
			ShowScreen(MainScreens.PlayScreen);
		}

		public void ShowMatchSearching(string gameModeTitle = "")
		{
			if (!string.IsNullOrEmpty(gameModeTitle))
			{
				modeTitleInSearchingScreen.text = gameModeTitle;
			}
			ShowScreen(MainScreens.MatchSearching, false);
		}

		public void ShowShareEnergyScreen()
		{
			ShowScreen(MainScreens.ShareEnergyScreen, false);
			OverrideOnBack(delegate
			{
			});
		}

		public void HideShareEnergyScreen()
		{
			ClearOnBackOverride();
			ShowLast();
		}

		public MainScreens GetCurrentPanel()
		{
			if (animator.isActiveAndEnabled)
			{
				return (MainScreens)animator.GetInteger("ShowPanel");
			}
			return lastPanel;
		}

		private void SetPanel(MainScreens screen)
		{
			log.InfoFormat("SetPanel {0}", screen);
			switch (screen)
			{
			case MainScreens.Main:
				SendShowScreenStat(LogScreen.Main);
				break;
			case MainScreens.Parts:
				SendShowScreenStat(LogScreen.Garage);
				break;
			case MainScreens.CreateBattle:
				SendShowScreenStat(LogScreen.CreateCustomBattle);
				break;
			case MainScreens.MatchLobby:
				SendShowScreenStat(LogScreen.BattleLobby);
				break;
			case MainScreens.MatchSearching:
				SendShowScreenStat(LogScreen.SearchBattle);
				break;
			case MainScreens.PlayScreen:
				SendShowScreenStat(LogScreen.GameModes);
				break;
			case MainScreens.CustomBattleScreen:
				SendShowScreenStat(LogScreen.CustomBattles);
				break;
			case MainScreens.StarterPack:
				SendShowScreenStat(LogScreen.StarterPack);
				break;
			}
			if (animator.isActiveAndEnabled)
			{
				animator.SetInteger("ShowPanel", (int)screen);
			}
			lastPanel = screen;
			OnPanelShow(screen);
		}

		public void Lock()
		{
			locked = true;
		}

		public void Unlock()
		{
			locked = false;
		}

		public void ToProfile()
		{
			if (GetCurrentPanel() == MainScreens.UserProfile)
			{
				GoBack();
				return;
			}
			HistoryItem historyItem = new HistoryItem();
			historyItem.Key = "ShowGameModeSelect";
			historyItem.OnBackToThis = delegate
			{
			};
			historyItem.Action = delegate
			{
				animator.SetInteger("ShowPanel", -5);
				SetPanel(MainScreens.UserProfile);
			};
			HistoryItem item = historyItem;
			ShowHistoryItem(item);
			backButton.SetActive(true);
		}

		public void ShowNewUI()
		{
			NodeClassInstanceDescription orCreateNodeClassDescription = NodeDescriptionRegistry.GetOrCreateNodeClassDescription(typeof(SingleNode<MainScreenComponent>));
			ICollection<Entity> entities = Flow.Current.NodeCollector.GetEntities(orCreateNodeClassDescription.NodeDescription);
			if (entities.Count == 0)
			{
				ScheduleEvent<ShowScreenNoAnimationEvent<MainScreenComponent>>(EngineService.EntityStub);
			}
		}

		public void ShowHome()
		{
			if (currentlyShown != null && currentlyShown.OnGoFromThis != null)
			{
				currentlyShown.OnGoFromThis();
			}
			ClearHistory();
			Instance.ShowNewUI();
			Instance.ShowMain();
		}

		public void OverrideOnBack(Action onBack)
		{
			onBackOverride = onBack;
		}

		public void ClearOnBackOverride()
		{
			onBackOverride = null;
		}

		public void ToggleNews(bool showNews)
		{
			animator.SetBool("newsIsShow", showNews);
		}

		public void ShowDesertIcon(int battlesCount)
		{
			deserterIcon.SetActive(true);
			TooltipShowBehaviour component = deserterIcon.GetComponent<TooltipShowBehaviour>();
			component.TipText = component.localizedTip.Value.Replace("{0}", battlesCount.ToString()).Replace("{1}", Pluralize(battlesCount));
		}

		public void HideDeserterIcon()
		{
			deserterIcon.SetActive(false);
		}

		public void ShowDeserterDesc(int battlesCount, bool inLobby)
		{
			deserterDesc.Rect.anchoredPosition = ((!inLobby) ? new Vector2(deserterDesc.Rect.anchoredPosition.x, -170f) : new Vector2(deserterDesc.Rect.anchoredPosition.x, -187f));
			deserterDesc.ShowDescription(deserterDescLocalized.Value.Replace("{0}", battlesCount.ToString()).Replace("{1}", Pluralize(battlesCount)));
		}

		public void HideDeserterDesc()
		{
			deserterDesc.Hide();
		}

		private string Pluralize(int amount)
		{
			switch (CasesUtil.GetCase(amount))
			{
			case CaseType.DEFAULT:
				return battlesDef.Value;
			case CaseType.ONE:
				return battlesOne.Value;
			case CaseType.TWO:
				return battlesTwo.Value;
			default:
				throw new Exception("ivnalid case");
			}
		}

		public void SendShowScreenStat(LogScreen screen)
		{
			ScheduleEvent(new ChangeScreenLogEvent(screen), EngineService.EntityStub);
		}
	}
}
