using System.Collections;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class UpdateRankEffectQueueUvAnimation : MonoBehaviour
	{
		public int RowsFadeIn = 4;

		public int ColumnsFadeIn = 4;

		public int RowsLoop = 4;

		public int ColumnsLoop = 4;

		public float Fps = 20f;

		public bool IsBump;

		public Material NextMaterial;

		private int index;

		private int count;

		private int allCount;

		private float deltaTime;

		private bool isVisible;

		private bool isFadeHandle;

		private void Start()
		{
			deltaTime = 1f / Fps;
			InitDefaultTex(RowsFadeIn, ColumnsFadeIn);
		}

		private void InitDefaultTex(int rows, int colums)
		{
			count = rows * colums;
			index += colums - 1;
			Vector2 value = new Vector2(1f / (float)colums, 1f / (float)rows);
			GetComponent<Renderer>().material.SetTextureScale("_MainTex", value);
			if (IsBump)
			{
				GetComponent<Renderer>().material.SetTextureScale("_BumpMap", value);
			}
		}

		private void OnBecameVisible()
		{
			isVisible = true;
			StartCoroutine(UpdateTiling());
		}

		private void OnBecameInvisible()
		{
			isVisible = false;
		}

		private IEnumerator UpdateTiling()
		{
			while (isVisible && allCount != count)
			{
				allCount++;
				index++;
				if (index >= count)
				{
					index = 0;
				}
				Vector2 offset = (isFadeHandle ? new Vector2((float)index / (float)ColumnsLoop - (float)(index / ColumnsLoop), 1f - (float)(index / ColumnsLoop) / (float)RowsLoop) : new Vector2((float)index / (float)ColumnsFadeIn - (float)(index / ColumnsFadeIn), 1f - (float)(index / ColumnsFadeIn) / (float)RowsFadeIn));
				if (!isFadeHandle)
				{
					GetComponent<Renderer>().material.SetTextureOffset("_MainTex", offset);
					if (IsBump)
					{
						GetComponent<Renderer>().material.SetTextureOffset("_BumpMap", offset);
					}
				}
				else
				{
					GetComponent<Renderer>().material.SetTextureOffset("_MainTex", offset);
					if (IsBump)
					{
						GetComponent<Renderer>().material.SetTextureOffset("_BumpMap", offset);
					}
				}
				if (allCount == count)
				{
					isFadeHandle = true;
					GetComponent<Renderer>().material = NextMaterial;
					InitDefaultTex(RowsLoop, ColumnsLoop);
				}
				yield return new WaitForSeconds(deltaTime);
			}
		}
	}
}
