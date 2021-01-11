using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientProtocol.API;

namespace Lobby.ClientUserProfile.API
{
	[Shared]
	[SerialVersionUID(1457515023113L)]
	public class ConfirmedUserEmailComponent : Component, ComponentServerChangeListener
	{
		private string email;

		[Inject]
		public static EngineService EngineService
		{
			get;
			set;
		}

		public string Email
		{
			get
			{
				return email;
			}
			set
			{
				email = value;
			}
		}

		public bool Subscribed
		{
			get;
			set;
		}

		void ComponentServerChangeListener.ChangedOnServer(Entity entity)
		{
			EngineService.Engine.ScheduleEvent<ConfirmedUserEmailChangedEvent>(entity);
		}
	}
}
