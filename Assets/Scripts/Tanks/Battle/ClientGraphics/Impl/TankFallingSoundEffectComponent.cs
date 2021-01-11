using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class TankFallingSoundEffectComponent : BehaviourComponent
	{
		[SerializeField]
		private AudioSource fallingSourceAsset;

		[SerializeField]
		private AudioClip[] fallingClips;

		[SerializeField]
		private AudioSource collisionSourceAsset;

		[SerializeField]
		private float minPower = 1f;

		[SerializeField]
		private float maxPower = 64f;

		public int FallingClipIndex
		{
			get;
			set;
		}

		public AudioClip[] FallingClips
		{
			get
			{
				return fallingClips;
			}
			set
			{
				fallingClips = value;
			}
		}

		public AudioSource FallingSourceAsset
		{
			get
			{
				return fallingSourceAsset;
			}
			set
			{
				fallingSourceAsset = value;
			}
		}

		public AudioSource CollisionSourceAsset
		{
			get
			{
				return collisionSourceAsset;
			}
			set
			{
				collisionSourceAsset = value;
			}
		}

		public float MinPower
		{
			get
			{
				return minPower;
			}
			set
			{
				minPower = value;
			}
		}

		public float MaxPower
		{
			get
			{
				return maxPower;
			}
			set
			{
				maxPower = value;
			}
		}

		private void Awake()
		{
			FallingClipIndex = 0;
		}
	}
}
