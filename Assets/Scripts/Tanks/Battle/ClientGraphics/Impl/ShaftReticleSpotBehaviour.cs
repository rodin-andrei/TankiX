using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ShaftReticleSpotBehaviour : MonoBehaviour
	{
		[SerializeField]
		private float minSpotScale = 1f;

		[SerializeField]
		private float maxSpotScale = 8f;

		[SerializeField]
		private float minSpotDistance = 50f;

		[SerializeField]
		private float maxSpotDistance = 5000f;

		private new RectTransform transform;

		public void Init()
		{
			transform = base.gameObject.GetComponent<RectTransform>();
		}

		public void SetSizeByDistance(float distance, bool isInsideTankPart)
		{
			float num = CalculateScaleByDistance(distance, isInsideTankPart);
			transform.localScale = new Vector3(num, num, 1f);
		}

		public void SetDefaultSize()
		{
			transform.localScale = Vector3.one;
		}

		private float CalculateScaleByDistance(float distance, bool isInsideTankPart)
		{
			if (isInsideTankPart)
			{
				return maxSpotScale;
			}
			if (distance < minSpotDistance)
			{
				return maxSpotScale;
			}
			if (distance > maxSpotDistance)
			{
				return minSpotScale;
			}
			float num = distance - minSpotDistance;
			return (1f - num / (maxSpotDistance - minSpotDistance)) * (maxSpotScale - minSpotScale) + minSpotScale;
		}
	}
}
