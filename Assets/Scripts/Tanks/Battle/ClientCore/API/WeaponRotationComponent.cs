using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Battle.ClientCore.API
{
	[Shared]
	[SerialVersionUID(1432792458422L)]
	public class WeaponRotationComponent : Component
	{
		private float speed;

		private float acceleration;

		private float baseSpeed;

		public float Speed
		{
			get
			{
				return speed;
			}
			set
			{
				speed = value;
			}
		}

		public float Acceleration
		{
			get
			{
				return acceleration;
			}
			set
			{
				acceleration = value;
			}
		}

		public float BaseSpeed
		{
			get
			{
				return baseSpeed;
			}
			set
			{
				baseSpeed = value;
			}
		}
	}
}
