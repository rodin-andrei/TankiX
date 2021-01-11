using Platform.Library.ClientProtocol.API;
using Tanks.Battle.ClientCore.Impl;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	public abstract class BaseShotEvent : TimeValidateEvent
	{
		[ProtocolOptional]
		public Vector3 ShotDirection
		{
			get;
			set;
		}

		public int ShotId
		{
			get;
			set;
		}

		public BaseShotEvent()
		{
		}

		public BaseShotEvent(Vector3 shotDirection)
		{
			ShotDirection = shotDirection;
		}
	}
}
