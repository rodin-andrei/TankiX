using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public class CameraVisibleTriggerComponent : BehaviourComponent
	{
		public Transform MainCameraTransform
		{
			get;
			set;
		}

		public bool IsVisible
		{
			get;
			set;
		}

		public float DistanceToCamera
		{
			get
			{
				if (MainCameraTransform != null)
				{
					return Vector3.Distance(MainCameraTransform.position, base.gameObject.transform.position);
				}
				return 0f;
			}
		}

		public bool IsVisibleAtRange(float testRange)
		{
			return IsVisible && DistanceToCamera < testRange;
		}

		private void OnBecameVisible()
		{
			IsVisible = true;
		}

		private void OnBecameInvisible()
		{
			IsVisible = false;
		}
	}
}
