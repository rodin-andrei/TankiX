using System;

namespace Tanks.Lobby.ClientGarage.API
{
	public class GarageCategory
	{
		public static GarageCategory WEAPONS = new GarageCategory("weapons", typeof(WeaponItemComponent), false);

		public static GarageCategory HULLS = new GarageCategory("hulls", typeof(TankItemComponent), false);

		public static GarageCategory PAINTS = new GarageCategory("paints", typeof(PaintItemComponent), false);

		public static GarageCategory SHELLS = new GarageCategory("shells", typeof(ShellItemComponent), true);

		public static GarageCategory SKINS = new GarageCategory("skins", typeof(SkinItemComponent), true);

		public static GarageCategory GRAFFITI = new GarageCategory("graffiti", typeof(GraffitiItemComponent), false);

		public static GarageCategory BLUEPRINTS = new GarageCategory("blueprints", typeof(GameplayChestItemComponent), false);

		public static GarageCategory CONTAINERS = new GarageCategory("containers", typeof(ContainerMarkerComponent), false);

		public static GarageCategory MODULES = new GarageCategory("modules", typeof(ModuleItemComponent), true);

		public static GarageCategory[] Values = new GarageCategory[9]
		{
			WEAPONS,
			PAINTS,
			HULLS,
			SHELLS,
			SKINS,
			GRAFFITI,
			BLUEPRINTS,
			CONTAINERS,
			MODULES
		};

		private string linkPart;

		private Type itemMarkerComponentType;

		private bool needParent;

		public string Name
		{
			get
			{
				return linkPart.ToUpper();
			}
		}

		public string LinkPart
		{
			get
			{
				return linkPart;
			}
		}

		public Type ItemMarkerComponentType
		{
			get
			{
				return itemMarkerComponentType;
			}
		}

		public bool NeedParent
		{
			get
			{
				return needParent;
			}
		}

		public GarageCategory(string linkPart, Type itemMarkerComponentType, bool needParent)
		{
			this.linkPart = linkPart;
			this.itemMarkerComponentType = itemMarkerComponentType;
			this.needParent = needParent;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
