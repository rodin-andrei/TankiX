using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.Impl
{
	public class GlassBreaker : MonoBehaviour
	{
		public GameObject[] prefabs;

		private RectTransform buttonTransform;

		[SerializeField]
		private List<RectTransform> glassTransforms = new List<RectTransform>();

		private Dictionary<RectTransform, float> normalizedPositions = new Dictionary<RectTransform, float>();

		private int previousCrack;

		private void Start()
		{
			if (glassTransforms.Count == 0)
			{
				BreakGlass();
			}
		}

		private void OnRectTransformDimensionsChange()
		{
			AdjustPostion();
		}

		private void AdjustPostion()
		{
			foreach (RectTransform glassTransform in glassTransforms)
			{
				glassTransform.anchoredPosition = RandomPosition(glassTransform);
			}
		}

		private void CreateBottomGlassCrack()
		{
			RectTransform rectTransform = CreateGlassCrack();
			rectTransform.localScale = new Vector3(1f, 1f);
			Vector2 vector3 = (rectTransform.anchorMax = (rectTransform.anchorMin = new Vector2(0f, 0f)));
			rectTransform.pivot = default(Vector2);
			rectTransform.anchoredPosition = RandomPosition(rectTransform);
		}

		private void CreateTopGlassCrack()
		{
			RectTransform rectTransform = CreateGlassCrack();
			rectTransform.localScale = new Vector3(1f, -1f);
			Vector2 vector3 = (rectTransform.anchorMax = (rectTransform.anchorMin = new Vector2(0f, 1f)));
			rectTransform.pivot = default(Vector2);
			rectTransform.anchoredPosition = RandomPosition(rectTransform);
			rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y - 5f);
		}

		private RectTransform CreateGlassCrack()
		{
			GameObject original = RandomCrack();
			GameObject gameObject = Object.Instantiate(original);
			RectTransform component = gameObject.GetComponent<RectTransform>();
			glassTransforms.Add(component);
			normalizedPositions.Add(component, Random.Range(0f, 1f));
			gameObject.transform.SetParent(base.transform, false);
			return component;
		}

		private Vector2 RandomPosition(RectTransform rectTransform)
		{
			float x = normalizedPositions[rectTransform] * buttonTransform.rect.width;
			return new Vector2(x, 0f);
		}

		private GameObject RandomCrack()
		{
			int num;
			for (num = previousCrack; num == previousCrack; num = Random.Range(0, prefabs.Length))
			{
			}
			previousCrack = num;
			return prefabs[num];
		}

		public void BreakGlass()
		{
			buttonTransform = GetComponent<RectTransform>();
			ClearInstances();
			previousCrack = -1;
			if (Random.Range(0, 2) == 0)
			{
				CreateTopGlassCrack();
			}
			if (Random.Range(0, 2) == 0)
			{
				CreateBottomGlassCrack();
			}
		}

		private void ClearInstances()
		{
			foreach (RectTransform glassTransform in glassTransforms)
			{
				Object.DestroyImmediate(glassTransform.gameObject);
			}
			glassTransforms.Clear();
		}
	}
}
