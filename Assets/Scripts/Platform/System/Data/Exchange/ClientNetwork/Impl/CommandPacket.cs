using System.Collections.Generic;

namespace Platform.System.Data.Exchange.ClientNetwork.Impl
{
	public class CommandPacket
	{
		public List<Command> Commands
		{
			get;
			internal set;
		}

		public CommandPacket()
		{
		}

		public CommandPacket(List<Command> commands)
		{
			Commands = commands;
		}

		public void Append(CommandPacket newPacket)
		{
			Commands.AddRange(newPacket.Commands);
		}
	}
}
