using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientNavigation.API;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class BaseSelectScreenComponent : LocalizedScreenComponent, PaymentScreen
	{
		private IUIList list;

		public IUIList List
		{
			get
			{
				return list;
			}
		}

		protected override void Awake()
		{
			base.Awake();
			list = GetComponentInChildren<IUIList>();
		}
	}
}
