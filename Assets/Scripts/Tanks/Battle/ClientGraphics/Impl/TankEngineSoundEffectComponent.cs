using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class TankEngineSoundEffectComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private GameObject enginePrefab;

		public GameObject EnginePrefab
		{
			get
			{
				return enginePrefab;
			}
			set
			{
				enginePrefab = value;
			}
		}

		public HullSoundEngineController SoundEngineController
		{
			get;
			set;
		}
	}
}
