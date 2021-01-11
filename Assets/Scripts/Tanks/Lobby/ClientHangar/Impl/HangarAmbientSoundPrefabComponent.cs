using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Lobby.ClientHangar.Impl
{
	public class HangarAmbientSoundPrefabComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private HangarAmbientSoundController hangarAmbientSoundController;

		public HangarAmbientSoundController HangarAmbientSoundController
		{
			get
			{
				return hangarAmbientSoundController;
			}
			set
			{
				hangarAmbientSoundController = value;
			}
		}
	}
}
