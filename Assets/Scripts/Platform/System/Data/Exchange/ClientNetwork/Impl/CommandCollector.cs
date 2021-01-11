using System.Collections.Generic;

namespace Platform.System.Data.Exchange.ClientNetwork.Impl
{
	public class CommandCollector
	{
		public List<Command> Commands
		{
			get;
			set;
		}

		public CommandCollector()
		{
			Commands = new List<Command>();
		}

		public void Add(Command command)
		{
			Commands.Add(command);
		}

		public void Clear()
		{
			Commands.Clear();
		}
	}
}
