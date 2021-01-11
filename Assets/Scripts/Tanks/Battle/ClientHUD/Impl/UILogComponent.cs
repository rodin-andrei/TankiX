using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class UILogComponent : Component
	{
		public UILog UILog
		{
			get;
			set;
		}

		public UILogComponent(UILog uiLog)
		{
			UILog = uiLog;
		}
	}
}
