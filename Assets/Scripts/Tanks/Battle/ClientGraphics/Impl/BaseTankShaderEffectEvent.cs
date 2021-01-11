using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public abstract class BaseTankShaderEffectEvent : Event
	{
		public string Key
		{
			get;
			set;
		}

		public bool EnableException
		{
			get;
			set;
		}

		protected BaseTankShaderEffectEvent(string key, bool enableException = false)
		{
			Key = key;
			EnableException = enableException;
		}
	}
}
