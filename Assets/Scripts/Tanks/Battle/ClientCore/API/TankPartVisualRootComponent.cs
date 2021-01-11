using Tanks.Battle.ClientCore.Impl;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	public abstract class TankPartVisualRootComponent : MonoBehaviour
	{
		[SerializeField]
		private VisualTriggerMarkerComponent visualTriggerMarker;

		public VisualTriggerMarkerComponent VisualTriggerMarker
		{
			get
			{
				return visualTriggerMarker;
			}
		}
	}
}
