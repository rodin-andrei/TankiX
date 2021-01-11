using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class DomeWaveGenerator : MonoBehaviour
	{
		public float radius;

		public float speed;

		private Material mat;

		private int waveIndex;

		private const int MAX_WAVE_COUNT = 5;

		private List<Coroutine> waveCoroutines = new List<Coroutine>
		{
			null,
			null,
			null,
			null,
			null
		};

		public void Init()
		{
			mat = GetComponent<Renderer>().material;
			mat.SetFloat("_Radius0", 0.3f);
			mat.SetFloat("_Radius1", 0.3f);
			mat.SetFloat("_Radius2", 0.3f);
			mat.SetFloat("_Radius3", 0.3f);
			mat.SetFloat("_Radius4", 0.3f);
			waveIndex = 0;
		}

		public void GenerateWave(Vector3 hitPoint)
		{
			if (waveCoroutines[waveIndex] != null)
			{
				StopCoroutine(waveCoroutines[waveIndex]);
			}
			Coroutine value = StartCoroutine(GenerateWave(waveIndex, hitPoint));
			waveCoroutines[waveIndex] = value;
			waveIndex = ((waveIndex != 4) ? (waveIndex + 1) : 0);
		}

		private void OnDestroy()
		{
			StopAllCoroutines();
		}

		private IEnumerator GenerateWave(int waveIndex, Vector3 hitPoint)
		{
			for (float f = 0f; f <= radius; f += radius / speed)
			{
				mat.SetFloat("_Radius" + waveIndex, f);
				mat.SetVector("_pos" + waveIndex, hitPoint);
				yield return null;
			}
			waveCoroutines[waveIndex] = null;
		}
	}
}
