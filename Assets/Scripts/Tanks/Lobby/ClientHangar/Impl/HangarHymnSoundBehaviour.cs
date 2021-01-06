using UnityEngine;

namespace Tanks.Lobby.ClientHangar.Impl
{
	public class HangarHymnSoundBehaviour : MonoBehaviour
	{
		[SerializeField]
		private HangarHymnSoundFilter introFilter;
		[SerializeField]
		private HangarHymnSoundFilter hangarLoopFilter;
		[SerializeField]
		private HangarHymnSoundFilter battleResultLoopFilter;
	}
}
