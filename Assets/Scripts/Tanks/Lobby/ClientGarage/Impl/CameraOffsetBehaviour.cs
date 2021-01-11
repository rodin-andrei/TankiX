using System.Collections;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class CameraOffsetBehaviour : BehaviourComponent
	{
		[SerializeField]
		private float offsetX;

		[SerializeField]
		private float offsetY;

		[SerializeField]
		private float animationDuration = 0.2f;

		private Camera camera;

		private Coroutine coroutine;

		public float Offset
		{
			get
			{
				return offsetX;
			}
		}

		public void AnimateOffset(float offset)
		{
			if (coroutine != null)
			{
				StopCoroutine(coroutine);
				coroutine = null;
			}
			coroutine = StartCoroutine(AnimateTo(offset));
		}

		public void SetOffset(float offset)
		{
			offsetX = offset;
		}

		private IEnumerator AnimateTo(float offset)
		{
			float time = 0f;
			float initOffset = offsetX;
			for (; time < animationDuration; time += Time.deltaTime)
			{
				offsetX = Mathf.Lerp(initOffset, offset, time / animationDuration);
				yield return null;
			}
			offsetX = offset;
		}

		private void Awake()
		{
			camera = GetComponent<Camera>();
		}

		private void LateUpdate()
		{
			camera.transform.localPosition = new Vector3(offsetX, offsetY, 0f);
			camera.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
		}

		private void OnEnable()
		{
			Cursor.visible = true;
		}
	}
}
