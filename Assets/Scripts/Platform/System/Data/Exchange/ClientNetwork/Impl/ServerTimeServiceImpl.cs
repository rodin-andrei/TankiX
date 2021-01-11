using System;
using Platform.System.Data.Exchange.ClientNetwork.API;

namespace Platform.System.Data.Exchange.ClientNetwork.Impl
{
	public class ServerTimeServiceImpl : ServerTimeService, ServerTimeServiceInternal
	{
		private long initialServerTime;

		public long InitialServerTime
		{
			get
			{
				return initialServerTime;
			}
			set
			{
				initialServerTime = value;
				if (this.OnInitServerTime != null)
				{
					this.OnInitServerTime(value);
				}
			}
		}

		public event Action<long> OnInitServerTime;
	}
}
