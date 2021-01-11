using Platform.Library.ClientDataStructures.API;
using Platform.Library.ClientDataStructures.Impl.Cache;
using Platform.Library.ClientProtocol.API;

namespace Platform.Library.ClientProtocol.Impl
{
	public class ClientProtocolInstancesCacheImpl : ClientProtocolInstancesCache
	{
		private readonly Cache<ProtocolBuffer> protocolBufferCache;

		private readonly Cache<MemoryStreamData> memoryStreamDataCache;

		public ClientProtocolInstancesCacheImpl()
		{
			protocolBufferCache = new CacheImpl<ProtocolBuffer>(delegate(ProtocolBuffer a)
			{
				a.Clear();
			});
			memoryStreamDataCache = new CacheImpl<MemoryStreamData>(delegate(MemoryStreamData a)
			{
				a.Clear();
			});
		}

		public ProtocolBuffer GetProtocolBufferInstance()
		{
			return protocolBufferCache.GetInstance();
		}

		public void ReleaseProtocolBufferInstance(ProtocolBuffer protocolBuffer)
		{
			protocolBufferCache.Free(protocolBuffer);
		}

		public MemoryStreamData GetMemoryStreamDataInstance()
		{
			return memoryStreamDataCache.GetInstance();
		}

		public void ReleaseMemoryStreamData(MemoryStreamData memoryStreamData)
		{
			memoryStreamDataCache.Free(memoryStreamData);
		}
	}
}
