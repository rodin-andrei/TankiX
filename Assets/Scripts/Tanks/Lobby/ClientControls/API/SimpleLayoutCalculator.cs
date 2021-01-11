using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class SimpleLayoutCalculator
	{
		public class Element
		{
			public float Min;

			public float Flexible;

			public float Max;

			public float size;

			public float i;

			public float sizeIfNoLimits;

			public bool AtMin()
			{
				return size == Min;
			}

			public bool AtMax()
			{
				return Max > 0f && size == Max;
			}

			public bool Unlimited()
			{
				return Flexible > 0f && Max == 0f;
			}

			public bool IsFixed()
			{
				return Flexible == 0f;
			}

			public override string ToString()
			{
				return "[i=" + i + " sizeIfNoLimits=" + sizeIfNoLimits + string.Format(" Min: {0}, Flexible: {1}, Max: {2}, Size: {3}]", Min, Flexible, Max, size);
			}
		}

		private static readonly float EPSILON = 0.001f;

		public List<Element> elements = new List<Element>();

		private int elementIndex;

		public float totalMin;

		public float totalFlexible;

		public float totalMax;

		public bool unlimited;

		public int iterations;

		public int iterationsOuter;

		private float sizeLeft;

		private List<Element> unresolvedElements = new List<Element>();

		public int newCount;

		public void Reset(int count)
		{
			newCount = 0;
			EnsureArraySize(count);
			elementIndex = 0;
			totalMin = 0f;
			totalFlexible = 0f;
			totalMax = 0f;
			unlimited = false;
			iterations = 0;
			iterationsOuter = 0;
			unresolvedElements.Clear();
			unresolvedElements.Capacity = count;
		}

		public void AddElement(float flexible = 0f, float min = 0f, float max = 0f)
		{
			EnsureArraySize(elementIndex + 1);
			Element element = elements[elementIndex];
			element.i = elementIndex;
			element.Min = min;
			element.Flexible = flexible;
			element.Max = max;
			element.size = 0f;
			element.sizeIfNoLimits = 0f;
			totalMin += element.Min;
			totalFlexible += element.Flexible;
			totalMax += element.Max;
			unlimited |= element.Unlimited();
			if (!element.IsFixed())
			{
				unresolvedElements.Add(element);
			}
			elementIndex++;
		}

		public void Calculate(float maxSize)
		{
			SetArraySize(elementIndex);
			sizeLeft = ((!unlimited) ? Mathf.Min(totalMax, maxSize) : Mathf.Max(totalMin, maxSize));
			DistributeSizeToFixedElements();
			if (totalFlexible == 0f)
			{
				return;
			}
			while (!DistributedAll())
			{
				iterationsOuter++;
				DistributeSizeLeft();
				ClampMinMax();
				if (!DistributedAll())
				{
					if (sizeLeft > 0f)
					{
						ResolveElementsAtMax();
					}
					else
					{
						ResolveElementsAtMin();
					}
					RevertSizeFromUnresolvedElements();
				}
				if (iterations >= 100 || unresolvedElements.Count == 0)
				{
					break;
				}
			}
		}

		private void RevertSizeFromUnresolvedElements()
		{
			int num = 0;
			while (num < unresolvedElements.Count)
			{
				Element element = unresolvedElements[num];
				sizeLeft += element.size;
				element.size = 0f;
				num++;
				iterations++;
			}
		}

		private void DistributeSizeLeft()
		{
			float num = sizeLeft;
			int num2 = 0;
			while (num2 < unresolvedElements.Count)
			{
				Element element = unresolvedElements[num2];
				element.sizeIfNoLimits = num * element.Flexible / totalFlexible;
				float size = element.size;
				element.size = element.sizeIfNoLimits;
				sizeLeft -= element.size - size;
				num2++;
				iterations++;
			}
		}

		private bool DistributedAll()
		{
			return 0f - EPSILON < sizeLeft && sizeLeft < EPSILON;
		}

		private void ResolveElementsAtMin()
		{
			int num = 0;
			while (num < unresolvedElements.Count)
			{
				Element element = unresolvedElements[num];
				if (element.AtMin())
				{
					unresolvedElements.RemoveAt(num);
					totalFlexible -= element.Flexible;
					num--;
				}
				num++;
				iterations++;
			}
		}

		private void ResolveElementsAtMax()
		{
			int num = 0;
			while (num < unresolvedElements.Count)
			{
				Element element = unresolvedElements[num];
				if (element.AtMax())
				{
					unresolvedElements.RemoveAt(num);
					totalFlexible -= element.Flexible;
					num--;
				}
				num++;
				iterations++;
			}
		}

		private void ClampMinMax()
		{
			int num = 0;
			while (num < unresolvedElements.Count)
			{
				Element element = unresolvedElements[num];
				float size = element.size;
				if (element.sizeIfNoLimits < element.Min)
				{
					element.size = element.Min;
				}
				else if (element.Max > 0f && element.sizeIfNoLimits > element.Max)
				{
					element.size = element.Max;
				}
				sizeLeft -= element.size - size;
				num++;
				iterations++;
			}
		}

		private void DistributeSizeToFixedElements()
		{
			int num = 0;
			while (num < elements.Count)
			{
				Element element = elements[num];
				if (element.IsFixed())
				{
					sizeLeft -= (element.size = element.Min);
				}
				num++;
				iterations++;
			}
		}

		private void SetArraySize(int count)
		{
			EnsureArraySize(count);
			while (elements.Count > count)
			{
				elements.RemoveAt(elements.Count - 1);
			}
		}

		private void EnsureArraySize(int count)
		{
			while (elements.Count < count)
			{
				elements.Add(new Element());
				newCount++;
			}
		}
	}
}
