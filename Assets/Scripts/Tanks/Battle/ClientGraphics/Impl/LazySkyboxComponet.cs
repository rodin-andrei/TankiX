using Platform.Library.ClientUnityIntegration.API;
using Platform.Library.ClientResources.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class LazySkyboxComponet : BehaviourComponent
	{
		[SerializeField]
		private AssetReference skyBoxReference;
	}
}
