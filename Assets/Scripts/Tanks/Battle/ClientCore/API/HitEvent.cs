using System.Collections.Generic;
using System.Linq;
using Platform.Library.ClientProtocol.API;
using Tanks.Battle.ClientCore.Impl;

namespace Tanks.Battle.ClientCore.API
{
	public class HitEvent : TimeValidateEvent
	{
		[ProtocolOptional]
		public List<HitTarget> Targets
		{
			get;
			set;
		}

		[ProtocolOptional]
		public StaticHit StaticHit
		{
			get;
			set;
		}

		public int ShotId
		{
			get;
			set;
		}

		public HitEvent()
		{
			Targets = new List<HitTarget>();
		}

		public HitEvent(List<HitTarget> targets, StaticHit staticHit)
		{
			Targets = targets;
			StaticHit = staticHit;
		}

		public override string ToString()
		{
			return string.Format("Targets: {0}, StaticHit: {1}", string.Join(",", Targets.Select((HitTarget t) => t.ToString()).ToArray()), StaticHit);
		}
	}
}
