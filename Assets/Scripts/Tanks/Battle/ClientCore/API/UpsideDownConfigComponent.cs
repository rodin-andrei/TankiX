using System;
using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientCore.API
{
	public class UpsideDownConfigComponent : Component
	{
		private float angleCosToCheck;

		private float angleToNormal;

		public float UpsideDownAngleToNormal
		{
			get
			{
				return angleToNormal;
			}
			set
			{
				angleToNormal = value;
				angleCosToCheck = (float)(0.0 - Math.Cos(value * ((float)Math.PI / 180f)));
			}
		}

		public float DetectionPauseSec
		{
			get;
			set;
		}

		public int MaxRankForMessage
		{
			get;
			set;
		}

		public float GetUpsideDownCosToCheck()
		{
			return angleCosToCheck;
		}
	}
}
