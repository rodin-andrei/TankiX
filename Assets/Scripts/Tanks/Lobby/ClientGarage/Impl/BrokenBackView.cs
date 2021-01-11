using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class BrokenBackView : MonoBehaviour
	{
		private class BrokenBackPartsData
		{
			private Vector2 offsetMin;

			private Vector2 offsetMax;

			public Vector2 OffsetMin
			{
				get
				{
					return offsetMin;
				}
			}

			public Vector2 OffsetMax
			{
				get
				{
					return offsetMax;
				}
			}

			public BrokenBackPartsData(Vector2 offsetMin, Vector2 offsetMax)
			{
				this.offsetMin = offsetMin;
				this.offsetMax = offsetMax;
			}
		}

		[SerializeField]
		private float animationTime = 1f;

		[SerializeField]
		private AnimationCurve curve;

		[SerializeField]
		private RectTransform[] parts;

		private BrokenBackPartsData[] partsData;

		private float timer;

		private void Init()
		{
			if (partsData == null)
			{
				partsData = new BrokenBackPartsData[parts.Length];
				for (int i = 0; i < parts.Length; i++)
				{
					partsData[i] = new BrokenBackPartsData(parts[i].offsetMin, parts[i].offsetMax);
				}
			}
		}

		public void BreakBack()
		{
			Init();
			for (int i = 0; i < parts.Length; i++)
			{
				parts[i].offsetMin = partsData[i].OffsetMin;
				parts[i].offsetMax = partsData[i].OffsetMax;
			}
		}

		private void OnEnable()
		{
			Init();
			timer = 0f;
		}

		private void Update()
		{
			timer += Time.deltaTime;
			float t = curve.Evaluate(Mathf.Clamp01(timer / animationTime));
			for (int i = 0; i < parts.Length; i++)
			{
				parts[i].offsetMin = Vector3.Lerp(partsData[i].OffsetMin, Vector2.zero, t);
				parts[i].offsetMax = Vector3.Lerp(partsData[i].OffsetMax, Vector2.zero, t);
			}
			if (timer >= animationTime)
			{
				base.enabled = false;
			}
		}
	}
}
