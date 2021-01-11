using Tanks.Battle.ClientGraphics.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.impl
{
	public class HammerDecalProjectorComponent : DynamicDecalProjectorComponent
	{
		[SerializeField]
		private float combineHalfSize = 5f;

		public float CombineHalfSize
		{
			get
			{
				return combineHalfSize;
			}
			set
			{
				combineHalfSize = value;
			}
		}
	}
}
