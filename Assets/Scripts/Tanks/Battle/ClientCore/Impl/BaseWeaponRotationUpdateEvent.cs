using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public abstract class BaseWeaponRotationUpdateEvent<T> : Event where T : BaseWeaponRotationUpdateEvent<T>, new()
	{
		private static T INSTANCE = new T();

		public static T Instance
		{
			get
			{
				return INSTANCE;
			}
		}
	}
}
