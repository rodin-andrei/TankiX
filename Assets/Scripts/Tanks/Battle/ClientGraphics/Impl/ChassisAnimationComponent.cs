using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ChassisAnimationComponent : MonoBehaviour
	{
		public string trackPointName;
		public string movingWheelName;
		public string rotatingWheelName;
		public string wheelsMeshName;
		public float verticalOffset;
		public float horizontalOffset;
		public TrackBindingData leftTrackData;
		public TrackBindingData rightTrackData;
		public float highDistance;
		public float lowDistance;
		public float maxStretchingCoeff;
		public bool additionalRaycastsEnabled;
		public float tracksMaterialSpeedMultiplyer;
		public float smoothSpeed;
	}
}
