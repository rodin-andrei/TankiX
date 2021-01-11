using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public class StreamingDecalProjectorComponent : DynamicDecalProjectorComponent
	{
		[SerializeField]
		private float decalCreationPeriod = 0.2f;

		public float DecalCreationPeriod
		{
			get
			{
				return decalCreationPeriod;
			}
		}

		public float LastDecalCreationTime
		{
			get;
			set;
		}
	}
}
