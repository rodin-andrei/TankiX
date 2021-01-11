using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ApplyCameraTransformEvent : Event
	{
		private static ApplyCameraTransformEvent INSTANCE = new ApplyCameraTransformEvent();

		private bool positionSmoothingRatioValid;

		private bool rotationSmoothingRatioValid;

		private bool deltaTimeValid;

		private float positionSmoothingRatio;

		private float rotationSmoothingRatio;

		private float deltaTime;

		public float PositionSmoothingRatio
		{
			get
			{
				return positionSmoothingRatio;
			}
			set
			{
				positionSmoothingRatioValid = true;
				positionSmoothingRatio = value;
			}
		}

		public float RotationSmoothingRatio
		{
			get
			{
				return rotationSmoothingRatio;
			}
			set
			{
				rotationSmoothingRatioValid = true;
				rotationSmoothingRatio = value;
			}
		}

		public float DeltaTime
		{
			get
			{
				return deltaTime;
			}
			set
			{
				deltaTimeValid = true;
				deltaTime = value;
			}
		}

		public bool PositionSmoothingRatioValid
		{
			get
			{
				return positionSmoothingRatioValid;
			}
		}

		public bool RotationSmoothingRatioValid
		{
			get
			{
				return rotationSmoothingRatioValid;
			}
		}

		public bool DeltaTimeValid
		{
			get
			{
				return deltaTimeValid;
			}
		}

		private ApplyCameraTransformEvent()
		{
			ResetFields();
		}

		private void ResetFields()
		{
			positionSmoothingRatioValid = false;
			rotationSmoothingRatioValid = false;
			deltaTimeValid = false;
		}

		public static ApplyCameraTransformEvent ResetApplyCameraTransformEvent()
		{
			INSTANCE.ResetFields();
			return INSTANCE;
		}
	}
}
