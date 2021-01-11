using System.Collections.Generic;
using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Tanks.Lobby.ClientEntrance.API;
using Tanks.Lobby.ClientGarage.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class PresetUISystem : ECSSystem
	{
		public class GarageUserItemNode : Node
		{
			public MarketItemGroupComponent marketItemGroup;

			public DescriptionItemComponent descriptionItem;

			public UserGroupComponent userGroup;

			public ExperienceItemComponent experienceItem;

			public VisualPropertiesComponent visualProperties;

			public UpgradeLevelItemComponent upgradeLevelItem;
		}

		public class GarageMarketItemNode : Node
		{
			public DescriptionItemComponent descriptionItem;

			public MarketItemGroupComponent marketItemGroup;

			public MarketItemComponent marketItem;

			public VisualPropertiesComponent visualProperties;

			public GarageMarketItemRegisteredComponent garageMarketItemRegistered;
		}

		public class ParentGarageMarketItemNode : GarageMarketItemNode
		{
			public ParentGroupComponent parentGroup;
		}

		public class MarketGraffitiNode : Node
		{
			public MarketItemGroupComponent marketItemGroup;

			public MarketItemComponent marketItem;

			public GraffitiItemComponent graffitiItem;

			public ImageItemComponent imageItem;
		}

		public class ShellMarketItemNode : Node
		{
			public ShellItemComponent shellItem;

			public MarketItemComponent marketItem;

			public MarketItemGroupComponent marketItemGroup;

			public ParentGroupComponent parentGroup;

			public ImageItemComponent imageItem;
		}

		public class MountedTurretNode : GarageUserItemNode
		{
			public MountedItemComponent mountedItem;

			public WeaponItemComponent weaponItem;
		}

		public class MountedHullNode : GarageUserItemNode
		{
			public MountedItemComponent mountedItem;

			public TankItemComponent tankItem;
		}

		public class MountedSkin : Node
		{
			public SkinItemComponent skinItem;

			public MountedItemComponent mountedItem;

			public ParentGroupComponent parentGroup;

			public DescriptionItemComponent descriptionItem;

			public UserGroupComponent userGroup;
		}

		public class SelfUserNode : Node
		{
			public SelfUserComponent selfUser;

			public UserGroupComponent userGroup;
		}

		public class PresetNode : Node
		{
			public PresetItemComponent presetItem;

			public SelectedPresetComponent selectedPreset;

			public UserGroupComponent userGroup;
		}

		[Inject]
		public static GarageItemsRegistry GarageItemsRegistry
		{
			get;
			set;
		}

		[OnEventFire]
		public void LocalizeProperties(NodeAddedEvent e, [Combine] SingleNode<VisualPropertiesComponent> props, SingleNode<LocalizedVisualPropertiesComponent> locale)
		{
			Dictionary<string, string> names = locale.component.Names;
			Dictionary<string, string> units = locale.component.Units;
			foreach (MainVisualProperty mainProperty in props.component.MainProperties)
			{
				if (names.ContainsKey(mainProperty.Name))
				{
					mainProperty.Name = names[mainProperty.Name];
				}
			}
			foreach (VisualProperty property in props.component.Properties)
			{
				if (names.ContainsKey(property.Name))
				{
					property.Name = names[property.Name];
				}
				if (property.Unit != null && units.ContainsKey(property.Unit))
				{
					property.Unit = units[property.Unit];
				}
			}
		}

		[OnEventFire]
		public void LocalizeModuleProperties(NodeAddedEvent e, [Combine] SingleNode<ModuleVisualPropertiesComponent> props, SingleNode<LocalizedVisualPropertiesComponent> locale)
		{
			Dictionary<string, string> names = locale.component.Names;
			Dictionary<string, string> units = locale.component.Units;
			foreach (ModuleVisualProperty property in props.component.Properties)
			{
				if (names.ContainsKey(property.Name))
				{
					property.Name = names[property.Name];
				}
				if (property.Unit != null && units.ContainsKey(property.Unit))
				{
					property.Unit = units[property.Unit];
				}
			}
		}

		[OnEventComplete]
		public void InitTurret(NodeAddedEvent e, SingleNode<SelectedTurretUIComponent> turretUI, SelfUserNode self, [Context] PresetNode preset, [JoinByUser][Context] MountedTurretNode turret, [JoinByMarketItem][Context] ParentGarageMarketItemNode marketItem, [JoinByParentGroup][Context][Combine] MountedSkin mountedSkin)
		{
			if (preset.userGroup.Key == mountedSkin.userGroup.Key)
			{
				SetItem(turret, turretUI.component, mountedSkin);
			}
		}

		[OnEventComplete]
		public void InitHull(NodeAddedEvent e, SingleNode<SelectedHullUIComponent> hullUI, SelfUserNode self, [Context] PresetNode preset, [JoinByUser][Context] MountedHullNode hull, [JoinByMarketItem][Context] ParentGarageMarketItemNode marketItem, [JoinByParentGroup][Context][Combine] MountedSkin mountedSkin)
		{
			if (preset.userGroup.Key == mountedSkin.userGroup.Key)
			{
				SetItem(hull, hullUI.component, mountedSkin);
			}
		}

		[OnEventFire]
		public void InitTurret(NodeAddedEvent e, SingleNode<MainScreenComponent> ui, SelfUserNode self, [JoinByUser][Context] MountedTurretNode turret, [JoinByMarketItem][Context] GarageMarketItemNode marketItem)
		{
			ui.component.MountedTurret = GarageItemsRegistry.GetItem<TankPartItem>(turret.marketItemGroup.Key);
		}

		[OnEventFire]
		public void InitHull(NodeAddedEvent e, SingleNode<MainScreenComponent> ui, SelfUserNode self, [JoinByUser][Context] MountedHullNode hull, [JoinByMarketItem][Context] GarageMarketItemNode marketItem)
		{
			ui.component.MountedHull = GarageItemsRegistry.GetItem<TankPartItem>(hull.marketItemGroup.Key);
		}

		private void SetItem(GarageUserItemNode item, SelectedItemUI ui, MountedSkin mountedSkin)
		{
			ui.Set(GarageItemsRegistry.GetItem<TankPartItem>(item.marketItemGroup.Key), mountedSkin.descriptionItem.Name, item.upgradeLevelItem.Level);
		}

		[OnEventFire]
		public void GetGraffities(GetAllGraffitiesEvent e, Node any, [JoinAll][Combine] MarketGraffitiNode graffiti)
		{
			Add(e.Items, graffiti.Entity, graffiti.imageItem.SpriteUid);
		}

		[OnEventFire]
		public void GetShells(GetAllShellsEvent e, GarageMarketItemNode marketItem, [JoinByParentGroup][Combine] ShellMarketItemNode shell)
		{
			Add(e.Items, shell.Entity, shell.imageItem.SpriteUid);
		}

		private void Add<T>(List<T> list, Entity marketItem, string preview) where T : GarageItem, new()
		{
			T item = GarageItemsRegistry.GetItem<T>(marketItem.Id);
			item.Preview = preview;
			list.Add(item);
		}
	}
}
