using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientGarage.API;
using Tanks.Lobby.ClientNavigation.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class CustomizationUIComponent : BehaviourComponent
	{
		private TankPartItem selectedItem;

		[SerializeField]
		private VisualUI visualUI;

		[SerializeField]
		private ModulesScreenUIComponent modulesScreenUI;

		[SerializeField]
		private GarageSelectorUI garageSelectorUI;

		private string delayedTrigger;

		private int visualTab;

		[Inject]
		public new static EngineServiceInternal EngineService
		{
			get;
			set;
		}

		public TankPartItem Hull
		{
			get;
			set;
		}

		public TankPartItem Turret
		{
			get;
			set;
		}

		private MainScreenComponent MainScreen
		{
			get
			{
				return GetComponentInParent<MainScreenComponent>();
			}
		}

		public void Modules()
		{
			if (selectedItem == Turret)
			{
				TurretModules();
			}
			else
			{
				HullModules();
			}
		}

		public void Visual()
		{
			if (selectedItem == Turret)
			{
				TurretVisual(visualTab);
			}
			else
			{
				HullVisual(visualTab);
			}
		}

		public void HullVisual(int tab)
		{
			MainScreen.ShowHistoryItem(new MainScreenComponent.HistoryItem
			{
				OnGoFromThis = visualUI.ReturnCameraOffset,
				Key = "Customization",
				Action = delegate
				{
					GetComponentInParent<MainScreenComponent>().ShowCustomization();
					garageSelectorUI.gameObject.SetActive(true);
					SetVisualTab(tab);
					garageSelectorUI.onHullSelected = OnHullVisualSelected;
					garageSelectorUI.onTurretSelected = OnTurretVisualSelected;
					garageSelectorUI.SelectVisual();
					garageSelectorUI.SelectHull();
					ShowVisual(Hull, visualTab);
				}
			});
		}

		public void TurretVisual(int tab)
		{
			MainScreen.ShowHistoryItem(new MainScreenComponent.HistoryItem
			{
				OnGoFromThis = visualUI.ReturnCameraOffset,
				Key = "Customization",
				Action = delegate
				{
					GetComponentInParent<MainScreenComponent>().ShowCustomization();
					garageSelectorUI.gameObject.SetActive(true);
					SetVisualTab(tab);
					garageSelectorUI.onHullSelected = OnHullVisualSelected;
					garageSelectorUI.onTurretSelected = OnTurretVisualSelected;
					garageSelectorUI.SelectVisual();
					garageSelectorUI.SelectTurret();
					ShowVisual(Turret, visualTab);
				}
			});
		}

		public void TurretVisualNoSwitch(int tab)
		{
			MainScreen.ShowHistoryItem(new MainScreenComponent.HistoryItem
			{
				OnGoFromThis = visualUI.ReturnCameraOffset,
				Key = "CustomizationNoSwitch",
				Action = delegate
				{
					GetComponentInParent<MainScreenComponent>().ShowCustomization();
					garageSelectorUI.gameObject.SetActive(true);
					SetVisualTab(tab);
					garageSelectorUI.onHullSelected = OnHullVisualSelected;
					garageSelectorUI.onTurretSelected = OnTurretVisualSelected;
					garageSelectorUI.SelectVisual();
					garageSelectorUI.SelectTurret();
					garageSelectorUI.gameObject.SetActive(false);
					ShowVisual(Turret, visualTab);
				}
			});
		}

		public void HullVisualNoSwitch(int tab)
		{
			MainScreen.ShowHistoryItem(new MainScreenComponent.HistoryItem
			{
				OnGoFromThis = visualUI.ReturnCameraOffset,
				Key = "CustomizationNoSwitch",
				Action = delegate
				{
					GetComponentInParent<MainScreenComponent>().ShowCustomization();
					garageSelectorUI.gameObject.SetActive(true);
					SetVisualTab(tab);
					garageSelectorUI.onHullSelected = OnHullVisualSelected;
					garageSelectorUI.onTurretSelected = OnTurretVisualSelected;
					garageSelectorUI.SelectVisual();
					garageSelectorUI.SelectHull();
					ShowVisual(Hull, visualTab);
					garageSelectorUI.gameObject.SetActive(false);
				}
			});
		}

		public void HullModules()
		{
			selectedItem = Hull;
			GoToModulesScreenEvent eventInstance = new GoToModulesScreenEvent(TankPartModuleType.TANK);
			EngineService.Engine.ScheduleEvent(eventInstance, EngineService.EntityStub);
			MainScreen.SendShowScreenStat(LogScreen.TurretModules);
		}

		public void TurretModules()
		{
			selectedItem = Turret;
			GoToModulesScreenEvent eventInstance = new GoToModulesScreenEvent(TankPartModuleType.WEAPON);
			EngineService.Engine.ScheduleEvent(eventInstance, EngineService.EntityStub);
			MainScreen.SendShowScreenStat(LogScreen.TurretModules);
		}

		private void ShowVisual(TankPartItem item, int visualTab = 0)
		{
			selectedItem = item;
			if (base.gameObject.activeInHierarchy)
			{
				GetComponent<Animator>().SetTrigger("ShowVisual");
			}
			else
			{
				delayedTrigger = "ShowVisual";
			}
			visualUI.onEanble = delegate
			{
				visualUI.Set(item, visualTab);
			};
		}

		private void ShowTech(TankPartItem item)
		{
			selectedItem = item;
			if (!modulesScreenUI.gameObject.activeInHierarchy)
			{
				modulesScreenUI.onEanble = delegate
				{
					modulesScreenUI.SetItem(item);
				};
				if (base.gameObject.activeInHierarchy)
				{
					GetComponent<Animator>().SetTrigger("ShowTech");
				}
				else
				{
					delayedTrigger = "ShowTech";
				}
			}
			else
			{
				modulesScreenUI.SetItem(item);
			}
		}

		private void OnEnable()
		{
			if (delayedTrigger != null)
			{
				GetComponent<Animator>().SetTrigger(delayedTrigger);
				delayedTrigger = null;
			}
		}

		private void OnTurretVisualSelected()
		{
			TurretVisual(visualTab);
		}

		private void OnHullVisualSelected()
		{
			HullVisual(visualTab);
		}

		private void OnTurretTechSelected()
		{
			TurretModules();
		}

		private void OnHullTechSelected()
		{
			HullModules();
		}

		public void SetVisualTab(int tab)
		{
			if (tab >= 0)
			{
				visualTab = tab;
				MainScreenComponent.Instance.SetOnBackCallback(delegate
				{
					SetVisualTab(tab);
				});
			}
		}

		private void OnDisable()
		{
			visualUI.gameObject.SetActive(false);
			modulesScreenUI.gameObject.SetActive(false);
			visualUI.ReturnCameraOffset();
		}
	}
}
