using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class CustomTankBuilder : BehaviourComponent
	{
		[SerializeField]
		private Transform tankContainer;
		[SerializeField]
		private GameObject tankPrefab;
		[SerializeField]
		private BattleResultTankCameraController camera;
		[SerializeField]
		private Light light;
	}
}
