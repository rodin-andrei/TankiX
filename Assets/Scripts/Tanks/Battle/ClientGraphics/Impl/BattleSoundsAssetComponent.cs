using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class BattleSoundsAssetComponent : BehaviourComponent
	{
		[SerializeField]
		private BattleSoundsBehaviour battleSoundsBehaviour;

		public BattleSoundsBehaviour BattleSoundsBehaviour
		{
			get
			{
				return battleSoundsBehaviour;
			}
		}
	}
}
