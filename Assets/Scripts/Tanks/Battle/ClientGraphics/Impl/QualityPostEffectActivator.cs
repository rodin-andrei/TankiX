using UnityEngine;
using Tanks.Lobby.ClientSettings.API;
using System.Collections.Generic;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class QualityPostEffectActivator : MonoBehaviour
	{
		public Quality.QualityLevel quality;
		public DepthTextureMode depthTextureMode;
		[SerializeField]
		private List<MonoBehaviour> postEffects;
	}
}
