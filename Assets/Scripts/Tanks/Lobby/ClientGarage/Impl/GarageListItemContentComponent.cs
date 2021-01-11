using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class GarageListItemContentComponent : LocalizedControl, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private Text header;

		[SerializeField]
		private Text count;

		[SerializeField]
		private Text proficiencyLevel;

		[SerializeField]
		private ProgressBar progressBar;

		[SerializeField]
		private GameObject priceGameObject;

		[SerializeField]
		private GameObject xPriceGameObject;

		[SerializeField]
		private GameObject upgradeGameObject;

		[SerializeField]
		private GameObject arrow;

		[SerializeField]
		private Graphic unlockGraphic;

		[SerializeField]
		private GameObject previewContainer;

		[SerializeField]
		private GameObject previewPrefab;

		[SerializeField]
		private Text rareText;

		[SerializeField]
		private GameObject saleLabel;

		[SerializeField]
		private Text saleLabelText;

		public Text Header
		{
			get
			{
				return header;
			}
		}

		public Text Count
		{
			get
			{
				return count;
			}
		}

		public Text UpgradeLevel
		{
			get
			{
				return proficiencyLevel;
			}
		}

		public GameObject PriceGameObject
		{
			get
			{
				return priceGameObject;
			}
		}

		public GameObject XPriceGameObject
		{
			get
			{
				return xPriceGameObject;
			}
		}

		public GameObject UpgradeGameObject
		{
			get
			{
				return upgradeGameObject;
			}
		}

		public ProgressBar ProgressBar
		{
			get
			{
				return progressBar;
			}
		}

		public GameObject Arrow
		{
			get
			{
				return arrow;
			}
		}

		public bool RareTextVisibility
		{
			set
			{
				rareText.gameObject.SetActive(value);
			}
		}

		public string RareText
		{
			set
			{
				rareText.text = value;
			}
		}

		public bool SaleLabelVisible
		{
			set
			{
				saleLabel.SetActive(value);
			}
		}

		public string SaleLabelText
		{
			set
			{
				saleLabelText.text = value;
			}
		}

		public void SetUpgradeColor(Color color)
		{
			unlockGraphic.color = color;
		}

		private void Unlock()
		{
			GetComponent<Animator>().SetTrigger("Unlock");
		}

		public void AddPreview(string spriteUid, long count)
		{
			AddPreview(spriteUid).Count = count;
		}

		public GarageListItemContentPreviewComponent AddPreview(string spriteUid)
		{
			GameObject gameObject = Object.Instantiate(previewPrefab);
			gameObject.transform.SetParent(previewContainer.transform, false);
			GarageListItemContentPreviewComponent component = gameObject.GetComponent<GarageListItemContentPreviewComponent>();
			component.SetImage(spriteUid);
			return component;
		}
	}
}
