using UnityEngine;

namespace Tanks.Battle.ClientGraphics
{
	public class MineSoundsComponent : MonoBehaviour
	{
		[SerializeField]
		private AudioSource dropGroundSound;
		[SerializeField]
		private AudioSource dropNonGroundSound;
		[SerializeField]
		private AudioSource deactivationSound;
		[SerializeField]
		private AudioSource explosionSound;
	}
}
