using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;

namespace Tanks.Lobby.ClientProfile.Impl
{
	public class XCrystalsIndicatorComponent : BehaviourComponent
	{
		[SerializeField]
		private AnimatedLong number;

		public long Value
		{
			get
			{
				return number.Value;
			}
			set
			{
				number.Value = value;
			}
		}

		public void SetValueWithoutAnimation(long value)
		{
			number.SetImmediate(value);
		}
	}
}
