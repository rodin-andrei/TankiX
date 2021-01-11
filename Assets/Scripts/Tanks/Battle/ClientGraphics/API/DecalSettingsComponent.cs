using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientGraphics.API
{
	public class DecalSettingsComponent : Component
	{
		private int maxCount;

		private float lifeTimeMultipler;

		private float maxDistanceToCamera;

		private bool enableDecals;

		private int maxDecalsForHammer;

		public float MaxDistanceToCamera
		{
			get
			{
				return maxDistanceToCamera;
			}
			set
			{
				maxDistanceToCamera = value;
			}
		}

		public int MaxCount
		{
			get
			{
				return maxCount;
			}
			set
			{
				maxCount = value;
			}
		}

		public float LifeTimeMultipler
		{
			get
			{
				return lifeTimeMultipler;
			}
			set
			{
				lifeTimeMultipler = value;
			}
		}

		public bool EnableDecals
		{
			get
			{
				return enableDecals;
			}
			set
			{
				enableDecals = value;
			}
		}

		public int MaxDecalsForHammer
		{
			get
			{
				return maxDecalsForHammer;
			}
			set
			{
				maxDecalsForHammer = value;
			}
		}
	}
}
