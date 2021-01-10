using UnityEngine;
using UnityEngine.PostProcessing;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class HangarCameraPostProcessingActivator : MonoBehaviour
	{
		public PostProcessingProfile profile;
		[SerializeField]
		private MonoBehaviour Bloom;
		[SerializeField]
		private MonoBehaviour Fog;
		[SerializeField]
		private MonoBehaviour TargetBloom;
		public float FocusDistance;
		public Animator blurAnimator;
	}
}
