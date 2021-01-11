using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class LoginRewardItemUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
	{
		[SerializeField]
		private TextMeshProUGUI dayLabel;

		[SerializeField]
		private LoginRewardItemTooltip tooltip;

		[SerializeField]
		private ImageSkin imagePrefab;

		[SerializeField]
		private Transform imagesContainer;

		[SerializeField]
		private LoginRewardProgressBar progressBar;

		[SerializeField]
		private LocalizedField dayLocalizedField;

		public int Day
		{
			set
			{
				dayLabel.text = value + " " + dayLocalizedField.Value.ToUpper();
			}
		}

		public LoginRewardProgressBar.FillType fillType
		{
			set
			{
				progressBar.Fill(value);
			}
		}

		public void SetupLines(bool itemIsFirst, bool itemIsLast)
		{
			if (itemIsFirst)
			{
				progressBar.LeftLine.SetActive(false);
			}
			if (itemIsLast)
			{
				progressBar.RightLine.SetActive(false);
			}
		}

		public void AddItem(string imageUID, string name)
		{
			ImageSkin imageSkin = Object.Instantiate(imagePrefab, imagesContainer);
			imageSkin.SpriteUid = imageUID;
			imageSkin.gameObject.SetActive(true);
			string text = ((!string.IsNullOrEmpty(tooltip.Text)) ? "\n" : string.Empty) + name;
			tooltip.Text += text;
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			GetComponent<Animator>().SetBool("hover", true);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			GetComponent<Animator>().SetBool("hover", false);
		}
	}
}
