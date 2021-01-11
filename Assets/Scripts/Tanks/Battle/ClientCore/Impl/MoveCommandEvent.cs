using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Battle.ClientCore.Impl
{
	[Shared]
	[SerialVersionUID(6959116100408127452L)]
	public class MoveCommandEvent : Event
	{
		public MoveCommand MoveCommand
		{
			get;
			set;
		}

		public MoveCommandEvent()
		{
		}

		public MoveCommandEvent(MoveCommand moveCommand)
		{
			MoveCommand = moveCommand;
		}
	}
}
