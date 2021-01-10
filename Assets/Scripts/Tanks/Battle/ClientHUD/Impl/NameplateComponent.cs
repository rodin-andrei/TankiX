using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class NameplateComponent : BehaviourComponent
	{
		public float yOffset;
		public float appearanceSpeed;
		public float disappearanceSpeed;
		public bool alwaysVisible;
		[SerializeField]
		private EntityBehaviour redHealthBarPrefab;
		[SerializeField]
		private EntityBehaviour blueHealthBarPrefab;
		[SerializeField]
		private Graphic colorProvider;
	}
}
