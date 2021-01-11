using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Battle.ClientCore.Impl
{
	[Shared]
	[SerialVersionUID(-5670596162316552032L)]
	public class ShaftAimingWorkFinishStateComponent : TimeValidateComponent
	{
		public float FinishTimer
		{
			get;
			set;
		}

		public ShaftAimingWorkFinishStateComponent()
		{
			FinishTimer = 0f;
		}
	}
}
