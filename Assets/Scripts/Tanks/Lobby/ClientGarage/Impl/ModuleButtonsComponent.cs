using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.ECS.ClientEntitySystem.Impl;
using Platform.Kernel.OSGi.ClientCore.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientGarage.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ModuleButtonsComponent : LocalizedControl, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private Button mountButton;

		[SerializeField]
		private Button unmountButton;

		[SerializeField]
		private Button assembleButton;

		[SerializeField]
		private Button addResButton;

		private Entity selectedModule;

		private Entity selectedSlot;

		[SerializeField]
		private Text assembleText;

		[SerializeField]
		private Text mountText;

		[SerializeField]
		private Text unmountText;

		[Inject]
		public new static EngineService EngineService
		{
			get;
			set;
		}

		public Button MountButton
		{
			get
			{
				return mountButton;
			}
		}

		public Button UnmountButton
		{
			get
			{
				return unmountButton;
			}
		}

		public Button AssembleButton
		{
			get
			{
				return assembleButton;
			}
		}

		public Button AddResButton
		{
			get
			{
				return addResButton;
			}
		}

		public Entity SelectedModule
		{
			set
			{
				selectedModule = value;
			}
		}

		public Entity SelectedSlot
		{
			set
			{
				selectedSlot = value;
			}
		}

		public string AssembleText
		{
			get
			{
				return assembleText.text;
			}
			set
			{
				assembleText.text = value;
			}
		}

		public string MountText
		{
			get
			{
				return mountText.text;
			}
			set
			{
				mountText.text = value;
			}
		}

		public string UnmountText
		{
			get
			{
				return unmountText.text;
			}
			set
			{
				unmountText.text = value;
			}
		}

		protected override void Awake()
		{
			base.Awake();
			mountButton.onClick.AddListener(ScheduleForModuleAndSlotEvent<ModuleMountEvent>);
			unmountButton.onClick.AddListener(ScheduleForModuleAndSlotEvent<UnmountModuleFromSlotEvent>);
			assembleButton.onClick.AddListener(ScheduleForModuleEvent<RequestModuleAssembleEvent>);
			addResButton.onClick.AddListener(AddResources);
		}

		private void AddResources()
		{
			ScheduleEvent(new ShowGarageItemEvent
			{
				Item = Flow.Current.EntityRegistry.GetEntity(-370755132L)
			}, selectedModule);
		}

		private void ScheduleForModuleEvent<T>() where T : Platform.Kernel.ECS.ClientEntitySystem.API.Event, new()
		{
			ScheduleEvent<T>(selectedModule);
		}

		private void ScheduleForModuleAndSlotEvent<T>() where T : Platform.Kernel.ECS.ClientEntitySystem.API.Event, new()
		{
			NewEvent<T>().AttachAll(selectedModule, selectedSlot).Schedule();
		}
	}
}
