using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Lobby.ClientProfile.API
{
	[Shared]
	[SerialVersionUID(1473074767785L)]
	public class UserXCrystalsComponent : Component, ComponentServerChangeListener
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
			EngineService.Engine.ScheduleEvent<UserXCrystalsChangedEvent>(entity);
		}
	}
}
