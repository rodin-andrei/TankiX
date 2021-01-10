using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class VulcanBandAnimationComponent : ECSBehaviour
	{
		[SerializeField]
		private int materialIndex;
		[SerializeField]
		private float speed;
		[SerializeField]
		private float bandCooldownSec;
		[SerializeField]
		private float partCount;
		[SerializeField]
		private string[] textureNames;
	}
}
