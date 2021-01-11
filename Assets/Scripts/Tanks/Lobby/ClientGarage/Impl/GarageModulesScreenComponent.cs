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

		public GameObject ModulesListItemPrefab
		{
			get
			{
				return modulesListItemPrefab;
			}
			set
			{
				modulesListItemPrefab = value;
			}
		}

		public GameObject ResourcePriceLabelPrefab
		{
			get
			{
				return resourcePriceLabelPrefab;
			}
			set
			{
				resourcePriceLabelPrefab = value;
			}
		}

		public Text PlaceholderText
		{
			get
			{
				return placeholderText;
			}
		}

		public RectTransform ModulesListRoot
		{
			get
			{
				return modulesListRoot;
			}
			set
			{
				modulesListRoot = value;
			}
		}

		public void FadeOut()
		{
			fadable.SetBool("Visible", false);
		}

		public void FadeIn()
		{
			fadable.SetBool("Visible", true);
		}
	}
}
