using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using Platform.Library.ClientUnityIntegration.API;

namespace Tanks.Battle.ClientCore.API
{
	[Shared]
	[SerialVersionUID(5192591761194414739L)]
	public class DurationComponent : Component
	{
		private Date startedTime;

		public Date StartedTime
		{
			get
			{
				return startedTime;
			}
			set
			{
				startedTime = value;
			}
		}
	}
}
