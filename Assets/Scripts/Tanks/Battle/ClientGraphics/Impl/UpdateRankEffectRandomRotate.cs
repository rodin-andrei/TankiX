using System.Collections;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class UpdateRankEffectRandomRotate : MonoBehaviour
	{
		public bool isRotate = true;

		public int fps = 30;

		public int x = 100;

		public int y = 200;

		public int z = 300;

		private float rangeX;

		private float rangeY;

		private float rangeZ;

		private float deltaTime;

		private bool isVisible;

		private void Start()
		{
			deltaTime = 1f / (float)fps;
			rangeX = Random.Range(0, 10);
			rangeY = Random.Range(0, 10);
			rangeZ = Random.Range(0, 10);
		}

		private void OnBecameVisible()
		{
			isVisible = true;
			StartCoroutine(UpdateRotation());
		}

		private void OnBecameInvisible()
		{
			isVisible = false;
		}

		private IEnumerator UpdateRotation()
		{
			while (isVisible)
			{
				if (isRotate)
				{
					base.transform.Rotate(deltaTime * Mathf.Sin(Time.time + rangeX) * (float)x, deltaTime * Mathf.Sin(Time.time + rangeY) * (float)y, deltaTime * Mathf.Sin(Time.time + rangeZ) * (float)z);
				}
				yield return new WaitForSeconds(deltaTime);
			}
		}
	}
}
