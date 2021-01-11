using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	public struct SelfTargetHitEffectHUDData
	{
		private Vector3 enemyWeaponWorldSpace;

		private Vector2 boundsPosition;

		private Vector3 upwardsNRM;

		private Vector2 boundsPosCanvas;

		private Vector2 cnvSize;

		private float length;

		public Vector2 BoundsPosition
		{
			get
			{
				return boundsPosition;
			}
		}

		public Vector3 UpwardsNrm
		{
			get
			{
				return upwardsNRM;
			}
		}

		public float Length
		{
			get
			{
				return length;
			}
		}

		public Vector2 BoundsPosCanvas
		{
			get
			{
				return boundsPosCanvas;
			}
		}

		public Vector3 EnemyWeaponWorldSpace
		{
			get
			{
				return enemyWeaponWorldSpace;
			}
		}

		public Vector2 CnvSize
		{
			get
			{
				return cnvSize;
			}
		}

		public SelfTargetHitEffectHUDData(Vector3 enemyWeaponWorldSpace, Vector2 boundsPosition, Vector2 boundsPosCanvas, Vector3 upwardsNRM, Vector2 cnvSize, float length)
		{
			this.enemyWeaponWorldSpace = enemyWeaponWorldSpace;
			this.boundsPosition = boundsPosition;
			this.boundsPosCanvas = boundsPosCanvas;
			this.cnvSize = cnvSize;
			this.upwardsNRM = upwardsNRM;
			this.length = length;
		}
	}
}
