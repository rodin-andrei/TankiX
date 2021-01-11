using Platform.Library.ClientResources.API;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class LazySkyboxComponet : BehaviourComponent
	{
		[SerializeField]
		private AssetReference skyBoxReference;

		public AssetReference SkyBoxReference
		{
			get
			{
				return skyBoxReference;
			}
		}
	}
}
