using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class AmbientZoneSoundEffect : MonoBehaviour
	{
		private Transform listener;

		[SerializeField]
		private AmbientInnerSoundZone[] innerZones;

		[SerializeField]
		private AmbientOuterSoundZone outerZone;

		private int innerZonesLength;

		private AmbientSoundZone currentZone;

		private bool needToDestroy;

		private HashSet<AmbientSoundZone> playingZones;

		private void Update()
		{
			AmbientSoundZone ambientSoundZone = DefineCurrentAmbientZone();
			if (!object.ReferenceEquals(ambientSoundZone, currentZone))
			{
				currentZone.FadeOut();
				ambientSoundZone.FadeIn();
				currentZone = ambientSoundZone;
			}
		}

		private AmbientSoundZone DefineCurrentAmbientZone()
		{
			for (int i = 0; i < innerZonesLength; i++)
			{
				AmbientInnerSoundZone ambientInnerSoundZone = innerZones[i];
				if (ambientInnerSoundZone.IsActualZone(listener))
				{
					return ambientInnerSoundZone;
				}
			}
			return outerZone;
		}

		public void Play(Transform listener)
		{
			this.listener = listener;
			playingZones = new HashSet<AmbientSoundZone>();
			innerZonesLength = innerZones.Length;
			needToDestroy = false;
			for (int i = 0; i < innerZonesLength; i++)
			{
				AmbientInnerSoundZone ambientInnerSoundZone = innerZones[i];
				ambientInnerSoundZone.InitInnerZone();
			}
			base.transform.parent = listener;
			base.transform.localPosition = Vector3.zero;
			base.transform.localRotation = Quaternion.identity;
			currentZone = DefineCurrentAmbientZone();
			currentZone.FadeIn();
			base.enabled = true;
		}

		public void DisableZoneTransition()
		{
			base.enabled = false;
		}

		public void Stop()
		{
			needToDestroy = true;
			for (int i = 0; i < innerZonesLength; i++)
			{
				AmbientInnerSoundZone ambientInnerSoundZone = innerZones[i];
				ambientInnerSoundZone.FinalizeInnerZone();
			}
			currentZone.FadeOut();
			DisableZoneTransition();
		}

		public void RegisterPlayingAmbientZone(AmbientSoundZone zone)
		{
			playingZones.Add(zone);
		}

		public void UnregisterPlayingAmbientZone(AmbientSoundZone zone)
		{
			playingZones.Remove(zone);
		}

		public void FinalizeEffect()
		{
			if (needToDestroy && playingZones.Count <= 0)
			{
				Object.DestroyObject(base.gameObject);
			}
		}
	}
}
