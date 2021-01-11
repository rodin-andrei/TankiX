using System.Collections.Generic;
using Platform.Library.ClientProtocol.API;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	[SerialVersionUID(635824352161555226L)]
	public class ShaftAimingLaserComponent : BehaviourComponent
	{
		[SerializeField]
		private float maxLength = 1000f;

		[SerializeField]
		private float minLength = 8f;

		[SerializeField]
		private GameObject asset;

		[SerializeField]
		private float interpolationCoeff = 0.333f;

		public readonly List<ShaftAimingLaserBehaviour> EffectInstances = new List<ShaftAimingLaserBehaviour>();

		public ShaftAimingLaserBehaviour EffectInstance
		{
			get
			{
				if (EffectInstances.Count > 0)
				{
					return EffectInstances[0];
				}
				return null;
			}
			set
			{
				EffectInstances.RemoveAll((ShaftAimingLaserBehaviour item) => item == null);
				EffectInstances.Add(value);
			}
		}

		public GameObject Asset
		{
			get
			{
				return asset;
			}
			set
			{
				asset = value;
			}
		}

		public float MaxLength
		{
			get
			{
				return maxLength;
			}
			set
			{
				maxLength = value;
			}
		}

		public float MinLength
		{
			get
			{
				return minLength;
			}
			set
			{
				minLength = value;
			}
		}

		public float InterpolationCoeff
		{
			get
			{
				return interpolationCoeff;
			}
			set
			{
				interpolationCoeff = value;
			}
		}

		public Vector3 CurrentLaserDirection
		{
			get;
			set;
		}
	}
}
