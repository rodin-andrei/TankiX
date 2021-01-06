using UnityEngine;
using Tanks.Battle.ClientGraphics.API;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class BattleSoundsBehaviour : MonoBehaviour
	{
		[SerializeField]
		private float minRemainigRoundTimeSec;
		[SerializeField]
		private int minDMScoreDiff;
		[SerializeField]
		private int minTDMScoreDiff;
		[SerializeField]
		private int minCTFScoreDiff;
		[SerializeField]
		private AudioSource[] startSounds;
		[SerializeField]
		private AudioSource shortNeutralSound;
		[SerializeField]
		private AudioSource shortWinSound;
		[SerializeField]
		private AudioSource shortLostSound;
		[SerializeField]
		private AmbientSoundFilter victoryMelody;
		[SerializeField]
		private AmbientSoundFilter defeatMelody;
		[SerializeField]
		private AmbientSoundFilter neutralMelody;
	}
}
