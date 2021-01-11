using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientNavigation.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ShopTabManager : TabManager
	{
		private static ShopTabManager _instance;

		private static int _shopTabIndex;

		public static ShopTabManager Instance
		{
			get
			{
				return _instance;
			}
		}

		public static int shopTabIndex
		{
			get
			{
				return shopTabIndex;
			}
			set
			{
				if (_instance == null)
				{
					_shopTabIndex = value;
				}
				else
				{
					_instance.Show(value);
				}
			}
		}

		private void Awake()
		{
			_instance = this;
		}

		protected override void OnEnable()
		{
			Show(_shopTabIndex);
		}

		public override void Show(int newIndex)
		{
			_shopTabIndex = newIndex;
			base.Show(newIndex);
			LogScreen screen;
			switch (newIndex)
			{
			case 1:
				screen = LogScreen.ShopBlueprints;
				break;
			case 2:
				screen = LogScreen.ShopContainers;
				break;
			case 3:
				screen = LogScreen.ShopXCry;
				break;
			case 4:
				screen = LogScreen.ShopCry;
				break;
			case 5:
				screen = LogScreen.ShopPrem;
				break;
			case 6:
				screen = LogScreen.GoldBoxes;
				break;
			default:
				screen = LogScreen.ShopDeals;
				break;
			}
			MainScreenComponent.Instance.SendShowScreenStat(screen);
		}
	}
}
