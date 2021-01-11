using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class BulletShellTailBehavior : MonoBehaviour
	{
		[SerializeField]
		private int yFrames = 4;

		[SerializeField]
		private int fps = 4;

		[SerializeField]
		private LineRenderer lineRenderer;

		[SerializeField]
		private float zFrom = 0.5f;

		[SerializeField]
		private float zTo = -3f;

		[SerializeField]
		private float zTime = 0.25f;

		private float timer;

		private Vector2 size;

		private int lastIndex;

		private float frameOffset;

		private bool tailGrow;

		private void OnEnable()
		{
			timer = 0f;
			frameOffset = 1f / (float)yFrames;
			lineRenderer.material.SetTextureScale("_MainTex", new Vector2(1f, frameOffset));
			lastIndex = -1;
			tailGrow = false;
		}

		private void Update()
		{
			timer += Time.deltaTime;
			int num = Mathf.RoundToInt(timer * (float)fps) % yFrames;
			if (num != lastIndex)
			{
				Vector2 value = new Vector2(0f, frameOffset * (float)num);
				lineRenderer.material.SetTextureOffset("_MainTex", value);
				lastIndex = num;
			}
			if (timer <= zTime)
			{
				lineRenderer.SetPositions(new Vector3[2]
				{
					new Vector3(0f, 0f, Mathf.Lerp(zFrom, zTo, timer / zTime)),
					new Vector3(0f, 0f, zFrom)
				});
			}
			else if (!tailGrow)
			{
				tailGrow = true;
				lineRenderer.SetPositions(new Vector3[2]
				{
					new Vector3(0f, 0f, zTo),
					new Vector3(0f, 0f, zFrom)
				});
			}
		}
	}
}
