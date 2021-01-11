using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Battle.ClientGraphics.Impl
{
	[SerialVersionUID(635824351863025226L)]
	public class IsisCurrentSoundEffectComponent : Component
	{
		public SoundController SoundController
		{
			get;
			set;
		}

		public bool WasStarted
		{
			get;
			set;
		}

		public bool WasStopped
		{
			get;
			set;
		}

		public IsisCurrentSoundEffectComponent()
		{
			WasStarted = false;
			WasStopped = false;
		}
	}
}
