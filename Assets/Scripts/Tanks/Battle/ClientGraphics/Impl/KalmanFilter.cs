using Tanks.Battle.ClientCore.Impl;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class KalmanFilter
	{
		public static readonly float MEASUREMENT_NOISE = 2f;

		public static readonly float ENVIRONMENT_NOISE = 20f;

		public static readonly float FACTOR_REAL_VALUE_TO_PREVIOUS_VALUE = 1f;

		public static readonly float FACTOR_MEASURED_VALUE_TO_PREVIOUS_VALUE = 1f;

		public static readonly float INIT_COVARIANCE = 0.1f;

		private Vector3 predictedState;

		private float predictedCovariance;

		private float covariance;

		public Vector3 State
		{
			get;
			private set;
		}

		public KalmanFilter(Vector3 initState)
		{
			Reset(initState);
		}

		public void Reset(Vector3 initState)
		{
			State = initState;
			covariance = INIT_COVARIANCE;
		}

		public void Correct(Vector3 data)
		{
			TimeUpdatePrediction();
			MeasurementUpdateCorrection(data);
		}

		private void TimeUpdatePrediction()
		{
			predictedState = FACTOR_REAL_VALUE_TO_PREVIOUS_VALUE * State;
			predictedCovariance = FACTOR_REAL_VALUE_TO_PREVIOUS_VALUE * covariance * FACTOR_REAL_VALUE_TO_PREVIOUS_VALUE + MEASUREMENT_NOISE;
		}

		private void MeasurementUpdateCorrection(Vector3 data)
		{
			float num = FACTOR_MEASURED_VALUE_TO_PREVIOUS_VALUE * predictedCovariance / (FACTOR_MEASURED_VALUE_TO_PREVIOUS_VALUE * predictedCovariance * FACTOR_MEASURED_VALUE_TO_PREVIOUS_VALUE + ENVIRONMENT_NOISE);
			if (!PhysicsUtil.IsValidFloat(num))
			{
				Reset(State);
				return;
			}
			State = predictedState + num * (data - FACTOR_MEASURED_VALUE_TO_PREVIOUS_VALUE * predictedState);
			covariance = (1f - num * FACTOR_MEASURED_VALUE_TO_PREVIOUS_VALUE) * predictedCovariance;
		}
	}
}
