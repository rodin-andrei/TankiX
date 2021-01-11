using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class WeaponGyroscopeRotationComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public float weaponTurnCoeff = 1f;

		public float GyroscopePower
		{
			get;
			set;
		}

		public Vector3 ForwardDir
		{
			get;
			set;
		}

		public Vector3 UpDir
		{
			get;
			set;
		}

		public float WeaponTurnCoeff
		{
			get
			{
				return weaponTurnCoeff;
			}
			set
			{
				weaponTurnCoeff = value;
			}
		}

		public float DeltaAngleOfHullRotation
		{
			get;
			set;
		}
	}
}
