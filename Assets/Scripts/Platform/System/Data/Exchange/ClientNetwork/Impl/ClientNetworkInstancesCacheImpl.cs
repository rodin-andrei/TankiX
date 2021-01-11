using System.Collections.Generic;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientDataStructures.API;
using Platform.Library.ClientDataStructures.Impl.Cache;
using Platform.Library.ClientProtocol.API;
using Platform.System.Data.Exchange.ClientNetwork.API;

namespace Platform.System.Data.Exchange.ClientNetwork.Impl
{
	public class ClientNetworkInstancesCacheImpl : ClientNetworkInstancesCache
	{
		private readonly Cache<CommandPacket> commandPacketCache;

		private readonly Cache<List<Command>> commandsCollectionCache;

		[Inject]
		public static ClientProtocolInstancesCache ClientProtocolInstancesCache
		{
			get;
			set;
		}

		public ClientNetworkInstancesCacheImpl()
		{
			commandPacketCache = new CacheImpl<CommandPacket>();
			commandsCollectionCache = new CacheImpl<List<Command>>(delegate(List<Command> a)
			{
				a.Clear();
			});
		}

		public CommandPacket GetCommandPacketInstance(List<Command> commands)
		{
			CommandPacket instance = commandPacketCache.GetInstance();
			instance.Commands = commands;
			return instance;
		}

		public void ReleaseCommandPacketWithCommandsCollection(CommandPacket commandPacket)
		{
			ReleaseCommandCollection(commandPacket.Commands);
			commandPacketCache.Free(commandPacket);
		}

		public List<Command> GetCommandCollection()
		{
			return commandsCollectionCache.GetInstance();
		}

		public void ReleaseCommandCollection(List<Command> commands)
		{
			commandsCollectionCache.Free(commands);
		}
	}
}
