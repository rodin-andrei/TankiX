using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientHangar.Impl
{
	public class HangarTankCommonPrefabComponent : BehaviourComponent
	{
		[SerializeField]
		private GameObject tankCommonPrefab;

		public GameObject TankCommonPrefab
		{
			get
			{
				return tankCommonPrefab;
			}
		}
	}
}
