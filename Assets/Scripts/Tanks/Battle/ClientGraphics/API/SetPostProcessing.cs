using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public class SetPostProcessing : MonoBehaviour
	{
		[SerializeField]
		private MonoBehaviour Bloom;
		[SerializeField]
		private MonoBehaviour Fog;
		[SerializeField]
		private MonoBehaviour TargetBloom;
		public bool forcedFog;
		public bool lowRenderResolution;
	}
}
