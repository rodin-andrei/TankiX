using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	internal class TrackMarksComponent : BehaviourComponent
	{
		public int maxSectorsPerTrack;
		public int hideSectorsFrom;
		public Material material;
		public ParticleSystem[] particleSystems;
		public float baseAlpha;
		public int parts;
		public float markWidth;
		public float markTestShift;
		public float maxDistance;
		public float hitDetect;
		public float shiftToCenter;
		public long tick;
	}
}
