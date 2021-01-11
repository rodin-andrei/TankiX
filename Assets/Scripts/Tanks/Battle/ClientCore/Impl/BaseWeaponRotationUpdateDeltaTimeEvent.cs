namespace Tanks.Battle.ClientCore.Impl
{
	public abstract class BaseWeaponRotationUpdateDeltaTimeEvent<T> : BaseWeaponRotationUpdateEvent<T> where T : BaseWeaponRotationUpdateDeltaTimeEvent<T>, new()
	{
		public float DeltaTime
		{
			get;
			set;
		}

		public static T GetInstance(float dt)
		{
			T instance = BaseWeaponRotationUpdateEvent<T>.Instance;
			instance.DeltaTime = dt;
			return instance;
		}
	}
}
