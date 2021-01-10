using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ShaftAimingLaserComponent : BehaviourComponent
	{
		[SerializeField]
		private float maxLength;
		[SerializeField]
		private float minLength;
		[SerializeField]
		private GameObject asset;
		[SerializeField]
		private float interpolationCoeff;
	}
}
