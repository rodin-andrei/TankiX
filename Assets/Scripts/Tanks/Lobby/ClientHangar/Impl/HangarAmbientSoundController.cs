using UnityEngine;
using Tanks.Battle.ClientGraphics.API;

namespace Tanks.Lobby.ClientHangar.Impl
{
	public class HangarAmbientSoundController : MonoBehaviour
	{
		[SerializeField]
		private AmbientSoundFilter background;
		[SerializeField]
		private HangarHymnSoundBehaviour hymn;
	}
}
