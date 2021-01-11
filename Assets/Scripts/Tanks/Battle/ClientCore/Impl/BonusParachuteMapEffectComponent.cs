using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class BonusParachuteMapEffectComponent : BehaviourComponent
	{
		[SerializeField]
		private GameObject parachute;

		public GameObject Parachute
		{
			get
			{
				return parachute;
			}
		}
	}
}
