using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class GarageModulesScreenComponent : BehaviourComponent
	{
		[SerializeField]
		private GameObject modulesListItemPrefab;
		[SerializeField]
		private GameObject resourcePriceLabelPrefab;
		[SerializeField]
		private RectTransform modulesListRoot;
		[SerializeField]
		private Text placeholderText;
		[SerializeField]
		private Animator fadable;
	}
}
