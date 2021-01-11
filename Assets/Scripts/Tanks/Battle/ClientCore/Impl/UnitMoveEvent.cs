using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Battle.ClientCore.Impl
{
	[SerialVersionUID(1485519185293L)]
	public class UnitMoveEvent : Event
	{
		public Movement UnitMove
		{
			get;
			set;
		}

		public UnitMoveEvent(Movement move)
		{
			UnitMove = move;
		}

		public UnitMoveEvent()
		{
		}
	}
}
