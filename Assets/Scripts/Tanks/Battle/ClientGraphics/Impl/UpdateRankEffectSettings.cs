using UnityEngine;
using Tanks.Lobby.ClientUserProfile.API;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class UpdateRankEffectSettings : MonoBehaviour
	{
		public enum EffectTypeEnum
		{
			Projectile = 0,
			AOE = 1,
			Other = 2,
		}

		public enum DeactivationEnum
		{
			Deactivate = 0,
			DestroyAfterCollision = 1,
			DestroyAfterTime = 2,
			Nothing = 3,
		}

		public RankIconComponent icon;
		public EffectTypeEnum EffectType;
		public float ColliderRadius;
		public float EffectRadius;
		public bool UseMoveVector;
		public GameObject Target;
		public Vector3 MoveVector;
		public float MoveSpeed;
		public bool IsHomingMove;
		public float MoveDistance;
		public bool IsVisible;
		public DeactivationEnum InstanceBehaviour;
		public float DeactivateTimeDelay;
		public float DestroyTimeDelay;
		public LayerMask LayerMask;
	}
}
