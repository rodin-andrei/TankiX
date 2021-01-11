using System;
using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class TankOutlineMapEffectSwitchStateEvent : Event
	{
		public Type StateType
		{
			get;
			set;
		}

		public TankOutlineMapEffectSwitchStateEvent(Type stateType)
		{
			StateType = stateType;
		}
	}
	public class TankOutlineMapEffectSwitchStateEvent<T> : TankOutlineMapEffectSwitchStateEvent where T : Node
	{
		public TankOutlineMapEffectSwitchStateEvent()
			: base(typeof(T))
		{
		}
	}
}
