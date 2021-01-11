using System;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class AvatarButton : MonoBehaviour
	{
		private const string equipedFrameName = "equiped";

		private const string selectedFrameName = "selected";

		[SerializeField]
		private Button button;

		[SerializeField]
		private ImageSkin icon;

		[SerializeField]
		private ImageListSkin frame;

		[SerializeField]
		private GameObject selectedFrame;

		[SerializeField]
		private GameObject equipedFrame;

		[SerializeField]
		private GameObject lockImage;

		public Action OnPress = delegate
		{
		};

		public Func<int> GetIndex = () => 0;

		public Action OnDoubleClick = delegate
		{
		};

		private bool isUserItem;

		private float delta = 0.2f;

		private float time;

		private void Awake()
		{
			button.onClick.AddListener(OnPressButton);
		}

		private void OnPressButton()
		{
			OnPress();
			if (Time.realtimeSinceStartup - time < delta)
			{
				OnDoubleClick();
				time = 0f;
			}
			else
			{
				time = Time.realtimeSinceStartup;
			}
		}

		public void Init(string iconUid, string rarity, IAvatarStateChanger changer)
		{
			icon.SpriteUid = iconUid;
			frame.SelectSprite(rarity);
			changer.SetEquipped = SetEquipped;
			changer.SetSelected = SetSelected;
			changer.SetUnlocked = SetUnlocked;
			changer.OnBought = SetAsBought;
			lockImage.SetActive(false);
			Color white = Color.white;
			white.a = 0.1f;
			icon.GetComponent<Image>().color = white;
			frame.GetComponent<Image>().color = white;
		}

		public void SetSelected(bool selected)
		{
			selectedFrame.SetActive(selected);
		}

		public void SetEquipped(bool equipped)
		{
			equipedFrame.SetActive(equipped);
		}

		public void SetUnlocked(bool unlocked)
		{
			lockImage.SetActive(!unlocked);
		}

		public void SetAsBought()
		{
			isUserItem = true;
			Color white = Color.white;
			icon.GetComponent<Image>().color = white;
			frame.GetComponent<Image>().color = white;
		}
	}
}
