using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Platform.Library.ClientResources.Impl
{
	public class UrlComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public string Url
		{
			get;
			set;
		}

		public Hash128 Hash
		{
			get;
			set;
		}

		public uint CRC
		{
			get;
			set;
		}

		public bool Caching
		{
			get;
			set;
		}

		public bool NoErrorEvent
		{
			get;
			set;
		}

		public UrlComponent()
		{
			Caching = true;
		}

		public UrlComponent(string url, Hash128 hash, uint crc)
		{
			Url = url;
			CRC = crc;
			Hash = hash;
			Caching = true;
		}
	}
}
