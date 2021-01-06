using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ShaftAimingMapEffectComponent : MonoBehaviour
	{
		[SerializeField]
		private float shrubsHidingRadiusMin;
		[SerializeField]
		private float shrubsHidingRadiusMax;
		[SerializeField]
		private Shader hidingLeavesShader;
		[SerializeField]
		private Shader defaultLeavesShader;
		[SerializeField]
		private Shader hidingBillboardTreesShader;
		[SerializeField]
		private Shader defaultBillboardTreesShader;
	}
}
