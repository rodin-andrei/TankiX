using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Lobby.ClientHangar.Impl
{
	public class HangarConfigComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private float autoRotateSpeed = 15f;

		[SerializeField]
		private float keyboardRotateSpeed = 30f;

		[SerializeField]
		private float mouseRotateFactor = 0.7f;

		[SerializeField]
		private float decelerationRotateFactor = 1.5f;

		[SerializeField]
		private float autoRotateDelay = 30f;

		[SerializeField]
		private float flightToLocationTime = 1f;

		[SerializeField]
		private float flightToLocationHigh = 5f;

		[SerializeField]
		private float flightToTankTime = 1f;

		[SerializeField]
		private float flightToTankRadius = 2f;

		public float AutoRotateSpeed
		{
			get
			{
				return autoRotateSpeed;
			}
		}

		public float KeyboardRotateSpeed
		{
			get
			{
				return keyboardRotateSpeed;
			}
		}

		public float MouseRotateFactor
		{
			get
			{
				return mouseRotateFactor;
			}
		}

		public float DecelerationRotateFactor
		{
			get
			{
				return decelerationRotateFactor;
			}
		}

		public float AutoRotateDelay
		{
			get
			{
				return autoRotateDelay;
			}
		}

		public float FlightToLocationTime
		{
			get
			{
				return flightToLocationTime;
			}
		}

		public float FlightToTankTime
		{
			get
			{
				return flightToTankTime;
			}
		}

		public float FlightToTankRadius
		{
			get
			{
				return flightToTankRadius;
			}
		}

		public float FlightToLocationHigh
		{
			get
			{
				return flightToLocationHigh;
			}
		}
	}
}
