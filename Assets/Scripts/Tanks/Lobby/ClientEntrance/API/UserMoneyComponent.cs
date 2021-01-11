using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Lobby.ClientEntrance.API
{
	[Shared]
	[SerialVersionUID(9171752353079252620L)]
	public class UserMoneyComponent : Component, ComponentServerChangeListener
	{
		private long money;

		[Inject]
		public static EngineService EngineService
		{
			get;
			set;
		}

		public long Money
		{
			get
			{
				return money;
			}
			set
			{
				money = value;
			}
		}

		public void ChangedOnServer(Entity entity)
		{
			EngineService.Engine.ScheduleEvent<UserMoneyChangedEvent>(entity);
		}
	}
}
