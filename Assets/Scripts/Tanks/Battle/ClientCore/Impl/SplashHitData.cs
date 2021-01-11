using System.Collections.Generic;
using System.Linq;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class SplashHitData
	{
		private const string TARGETS_ARRAY_DELIMETER = ", ";

		private const string LOG_FORMAT = "Splash Hit Data: direct targets = [{0}] ; static hit = {1} ; splash center = {2} splash targets = [{3}]";

		private List<HitTarget> directTargets;

		private StaticHit staticHit;

		private Entity weaponHitEntity;

		private List<HitTarget> splashTargets;

		private List<GameObject> exclusionGameObjectForSplashRaycast;

		private Vector3 splashCenter;

		private bool splashCenterInitialized;

		public List<HitTarget> DirectTargets
		{
			get
			{
				return directTargets;
			}
		}

		public StaticHit StaticHit
		{
			get
			{
				return staticHit;
			}
		}

		public Entity WeaponHitEntity
		{
			get
			{
				return weaponHitEntity;
			}
		}

		public List<HitTarget> SplashTargets
		{
			get
			{
				return splashTargets;
			}
		}

		public List<GameObject> ExclusionGameObjectForSplashRaycast
		{
			get
			{
				return exclusionGameObjectForSplashRaycast;
			}
		}

		public Vector3 SplashCenter
		{
			get
			{
				return splashCenter;
			}
			set
			{
				splashCenterInitialized = true;
				splashCenter = value;
			}
		}

		public HashSet<Entity> ExcludedEntityForSplashHit
		{
			get;
			set;
		}

		public bool SplashCenterInitialized
		{
			get
			{
				return splashCenterInitialized;
			}
		}

		private SplashHitData()
		{
			splashCenterInitialized = false;
		}

		public static SplashHitData CreateSplashHitData(List<HitTarget> directTargets, StaticHit staticHit, Entity weaponHitEntity)
		{
			SplashHitData splashHitData = new SplashHitData();
			splashHitData.directTargets = directTargets;
			splashHitData.staticHit = staticHit;
			splashHitData.weaponHitEntity = weaponHitEntity;
			splashHitData.splashTargets = new List<HitTarget>();
			splashHitData.exclusionGameObjectForSplashRaycast = new List<GameObject>();
			splashHitData.splashCenter = Vector3.zero;
			splashHitData.ExcludedEntityForSplashHit = null;
			return splashHitData;
		}

		public override string ToString()
		{
			return string.Format("Splash Hit Data: direct targets = [{0}] ; static hit = {1} ; splash center = {2} splash targets = [{3}]", ConvertTargetsCollectionToString(directTargets), (staticHit != null) ? staticHit.ToString() : string.Empty, splashCenter.ToString(), ConvertTargetsCollectionToString(splashTargets));
		}

		private string ConvertTargetsCollectionToString(List<HitTarget> targets)
		{
			return string.Join(", ", targets.Select((HitTarget i) => i.ToString()).ToArray());
		}
	}
}
