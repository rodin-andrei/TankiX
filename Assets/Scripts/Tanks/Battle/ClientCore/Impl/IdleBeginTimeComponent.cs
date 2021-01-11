using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class IdleBeginTimeComponent : Component
	{
		private Date? idleBeginTime;

		public Date? IdleBeginTime
		{
			get
			{
				return idleBeginTime;
			}
			set
			{
				idleBeginTime = value;
			}
		}
	}
}
