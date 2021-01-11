using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class BezierPosition
	{
		private const float MAX_OFFSET = 0.1f;

		private float baseRatio = 0.05f;

		private float offset;

		public Vector2 cameraPosition = default(Vector2);

		public Vector2 point0 = new Vector2(1.45f, 5.45f);

		public Vector2 point1 = new Vector2(9.3f, 13.95f);

		public Vector2 point2 = new Vector2(22.45f, 15.65f);

		public Vector2 point3 = new Vector2(31.05f, 7.6f);

		public float elevationAngle;

		public float distanceToPivot;

		private float ratio
		{
			get
			{
				return Mathf.Clamp01(baseRatio + offset);
			}
		}

		public BezierPosition()
		{
			Apply();
		}

		public float GetBaseRatio()
		{
			return baseRatio;
		}

		public void SetBaseRatio(float value)
		{
			baseRatio = Mathf.Clamp01(value);
			Apply();
		}

		public float GetRatioOffset()
		{
			return (offset + 0.05f) / 0.1f;
		}

		public void SetRatioOffset(float value)
		{
			offset = Mathf.Lerp(-0.05f, 0.05f, Mathf.Clamp01(value));
			Apply();
		}

		public void Apply()
		{
			cameraPosition = Bezier.PointOnCurve(ratio, point0, point1, point2, point3);
			elevationAngle = Mathf.Atan2(cameraPosition.x, cameraPosition.y);
			distanceToPivot = cameraPosition.magnitude;
		}

		public float GetDistanceToPivot()
		{
			return distanceToPivot;
		}

		public float GetCameraHeight()
		{
			return cameraPosition.x;
		}

		public float GetCameraHorizontalDistance()
		{
			return cameraPosition.y;
		}
	}
}
