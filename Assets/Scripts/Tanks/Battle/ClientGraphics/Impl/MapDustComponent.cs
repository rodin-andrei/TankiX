using Platform.Library.ClientUnityIntegration.API;
using System;
using UnityEngine;
using Tanks.Lobby.ClientSettings.API;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class MapDustComponent : BehaviourComponent
	{
		[Serializable]
		public class MaskToDustEffect
		{
			public Vector2 GrayScaleRange;
			public Texture2D Mask;
			public DustEffectBehaviour EffectBehaviour;
		}

		[Serializable]
		public class MapDustEffect
		{
			public Transform Target;
			public MapDustComponent.MaskToDustEffect[] DustEffects;
		}

		public DustEffectBehaviour DefaultDust;
		public DustEffectBehaviour LowGraphicDust;
		public Quality.QualityLevel QualityForLowDust;
		public int ParentDeep;
		public MapDustEffect[] Targets;
	}
}
