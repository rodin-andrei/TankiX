using Tanks.Battle.ClientGraphics.API;
using UnityEngine;

namespace Tanks.Lobby.ClientHangar.Impl
{
	public class HangarHymnSoundFilter : SingleFadeSoundFilter
	{
		[SerializeField]
		private GameObject objectToDestroy;
	}
}
