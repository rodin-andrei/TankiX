using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class BattleResultTankCameraController : MonoBehaviour
	{
		private readonly Vector3 bestPlayerScreenPosition = new Vector3(-4.041f, 0.481f, 8.276f);

		private readonly Vector3 bestPlayerScreenRotation = new Vector3(-8.188f, -219.687f, 0.818f);

		private readonly Vector3 awardScreenPosition = new Vector3(-13.4f, 4.17f, 18.58f);

		private readonly Vector3 awardScreenRotation = new Vector3(9.449f, -219.436f, 0.811f);

		private readonly float bpFieldOfView = 70f;

		private readonly float awFieldOfView = 40f;

		private Camera cam;

		private RenderTexture renderTex;

		private void Awake()
		{
			cam = GetComponent<Camera>();
			cam.enabled = true;
		}

		public void SetRenderTexture(RenderTexture tex)
		{
			cam.targetTexture = tex;
		}

		public void SetupForBestPlayer()
		{
			base.transform.localPosition = bestPlayerScreenPosition;
			base.transform.localEulerAngles = bestPlayerScreenRotation;
			cam.fieldOfView = bpFieldOfView;
		}

		public void SetupForAwardScren()
		{
			base.transform.localPosition = awardScreenPosition;
			base.transform.localEulerAngles = awardScreenRotation;
			cam.fieldOfView = awFieldOfView;
		}
	}
}
