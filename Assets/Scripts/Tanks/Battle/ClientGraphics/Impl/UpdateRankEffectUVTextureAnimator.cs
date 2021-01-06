using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	internal class UpdateRankEffectUVTextureAnimator : MonoBehaviour
	{
		public Material[] AnimatedMaterialsNotInstance;
		public int Rows;
		public int Columns;
		public float Fps;
		public int OffsetMat;
		public Vector2 SelfTiling;
		public bool IsLoop;
		public bool IsReverse;
		public bool IsRandomOffsetForInctance;
		public bool IsBump;
		public bool IsHeight;
		public bool IsCutOut;
	}
}
