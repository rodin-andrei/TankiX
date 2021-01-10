using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class AbstractRPMSoundUpdater : MonoBehaviour
	{
		[SerializeField]
		protected bool alive;
		[SerializeField]
		protected HullSoundEngineController engine;
		[SerializeField]
		protected AbstractRPMSoundModifier parentModifier;
		[SerializeField]
		protected RPMSoundBehaviour rpmSoundBehaviour;
	}
}
