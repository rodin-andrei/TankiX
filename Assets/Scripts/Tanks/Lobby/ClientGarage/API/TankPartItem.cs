using System;
using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientGarage.Impl;

namespace Tanks.Lobby.ClientGarage.API
{
	public class TankPartItem : GarageItem
	{
		public enum TankPartItemType
		{
			Turret,
			Hull
		}

		private List<VisualItem> skins = new List<VisualItem>();

		public int UpgradeLevel
		{
			get
			{
				if (base.UserItem == null)
				{
					return 0;
				}
				return base.UserItem.GetComponent<UpgradeLevelItemComponent>().Level;
			}
		}

		public int AbsExperience
		{
			get
			{
				ExperienceToLevelUpItemComponent component = base.UserItem.GetComponent<ExperienceToLevelUpItemComponent>();
				return component.FinalLevelExperience - component.RemainingExperience;
			}
		}

		public ExperienceToLevelUpItemComponent Experience
		{
			get
			{
				return base.UserItem.GetComponent<ExperienceToLevelUpItemComponent>();
			}
		}

		public string Feature
		{
			get
			{
				return MarketItem.GetComponent<VisualPropertiesComponent>().Feature;
			}
		}

		public List<MainVisualProperty> MainProperties
		{
			get
			{
				return MarketItem.GetComponent<VisualPropertiesComponent>().MainProperties;
			}
		}

		public List<VisualProperty> Properties
		{
			get
			{
				return MarketItem.GetComponent<VisualPropertiesComponent>().Properties;
			}
		}

		public TankPartItemType Type
		{
			get;
			private set;
		}

		public override Entity MarketItem
		{
			get
			{
				return base.MarketItem;
			}
			set
			{
				base.MarketItem = value;
				if (value.HasComponent<WeaponItemComponent>())
				{
					Type = TankPartItemType.Turret;
					return;
				}
				if (value.HasComponent<TankItemComponent>())
				{
					Type = TankPartItemType.Hull;
					return;
				}
				throw new Exception("Invalid tank part type");
			}
		}

		public ICollection<VisualItem> Skins
		{
			get
			{
				return skins;
			}
		}
	}
}
