using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class BuyXCrystalsDialogComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI title;

		public void Show(bool showTitle = true)
		{
			MainScreenComponent.Instance.OverrideOnBack(Hide);
			title.gameObject.SetActive(showTitle);
			base.gameObject.SetActive(true);
			GetComponent<Animator>().SetBool("show", true);
		}

		public void Hide()
		{
			GetComponent<Animator>().SetBool("show", false);
			base.gameObject.SetActive(false);
		}

		private void Update()
		{
			if (InputMapping.Cancel)
			{
				Hide();
			}
		}
	}
}
