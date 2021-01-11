using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class TankDeadStateTextureComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private Texture2D deadColorTexture;

		[SerializeField]
		private Texture2D deadEmissionTexture;

		[SerializeField]
		private AnimationCurve heatEmission;

		[SerializeField]
		private AnimationCurve whiteToHeat;

		[SerializeField]
		private AnimationCurve paintToHeat;

		public Date FadeStart
		{
			get;
			set;
		}

		public float LastFade
		{
			get;
			set;
		}

		public AnimationCurve HeatEmission
		{
			get
			{
				return heatEmission;
			}
		}

		public AnimationCurve WhiteToHeatTexture
		{
			get
			{
				return whiteToHeat;
			}
		}

		public AnimationCurve PaintTextureToWhiteHeat
		{
			get
			{
				return paintToHeat;
			}
		}

		public Texture2D DeadColorTexture
		{
			get
			{
				return deadColorTexture;
			}
		}

		public Texture2D DeadEmissionTexture
		{
			get
			{
				return deadEmissionTexture;
			}
		}
	}
}
