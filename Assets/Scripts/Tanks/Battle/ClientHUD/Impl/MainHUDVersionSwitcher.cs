using Platform.Kernel.OSGi.ClientCore.API;
using Tanks.Battle.ClientCore.Impl;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class MainHUDVersionSwitcher : MonoBehaviour
	{
		[SerializeField]
		private RectTransform mainInfoRect;

		[SerializeField]
		private RectTransform inventoryRect;

		[SerializeField]
		private RectTransform effectsRect;

		[SerializeField]
		private RectTransform chatRect;

		[SerializeField]
		private GameObject playerAvatar;

		[SerializeField]
		private GameObject hpBarV1;

		[SerializeField]
		private GameObject hpBarV2;

		[SerializeField]
		private GameObject energyBarV1;

		[SerializeField]
		private GameObject energyBarV2;

		[SerializeField]
		private GameObject effectsTopImage;

		[SerializeField]
		private GameObject inventoryTopImage;

		[SerializeField]
		private GameObject bottomLongLineImage;

		[SerializeField]
		private GameObject killAssistLogV1;

		[SerializeField]
		private GameObject killAssistLogV2;

		[SerializeField]
		private GameObject battleChatInput;

		private Vector2 mainInfoV1Position = new Vector2(325f, 65f);

		private Vector2 mainInfoV2Position = new Vector2(0f, 40f);

		private Vector2 inventoryV1Position = new Vector2(-230f, 65f);

		private Vector2 inventoryV2Position = new Vector2(0f, -2.5f);

		private Vector2 effectsV1Position = new Vector2(0f, -14f);

		private Vector2 effectsV2Position = new Vector2(0f, -4.6f);

		private Vector2 chatV1Position = new Vector2(80f, 270f);

		private Vector2 chatV2Position = new Vector2(40f, 100f);

		private string key = "BattleHudVersion";

		public bool specMode;

		[Inject]
		public static InputManager InputManager
		{
			get;
			set;
		}

		public void SetCurrentHud()
		{
			SetHudVersion(specMode ? 1 : GetBattleHudVersion(), !specMode);
		}

		private void SwitchHud()
		{
			if (!specMode)
			{
				int battleHudVersion = GetBattleHudVersion();
				SetHudVersion((battleHudVersion != 1) ? 1 : 2);
			}
		}

		private void SetHudVersion(int v, bool saveToPlayerPrefs = true)
		{
			if (saveToPlayerPrefs)
			{
				PlayerPrefs.SetInt(key, v);
			}
			RectTransform rectTransform = mainInfoRect;
			Vector2 vector = ((v != 1) ? new Vector2(0.5f, 0f) : Vector2.zero);
			mainInfoRect.anchorMax = vector;
			rectTransform.anchorMin = vector;
			mainInfoRect.anchoredPosition = ((v != 1) ? mainInfoV2Position : mainInfoV1Position);
			RectTransform rectTransform2 = inventoryRect;
			vector = ((v != 1) ? new Vector2(0.5f, 0f) : new Vector2(1f, 0f));
			inventoryRect.anchorMax = vector;
			rectTransform2.anchorMin = vector;
			inventoryRect.anchoredPosition = ((v != 1) ? inventoryV2Position : inventoryV1Position);
			effectsRect.anchoredPosition = ((v != 1) ? effectsV2Position : effectsV1Position);
			chatRect.anchoredPosition = ((v != 1) ? chatV2Position : chatV1Position);
			playerAvatar.SetActive(v == 1);
			hpBarV1.SetActive(v == 1);
			energyBarV1.SetActive(v == 1);
			hpBarV2.SetActive(v == 2);
			energyBarV2.SetActive(v == 2);
			bottomLongLineImage.SetActive(v == 2);
			effectsTopImage.SetActive(v == 1);
			effectsRect.rotation = ((v != 1) ? Quaternion.identity : Quaternion.Euler(0f, -20f, 0f));
			inventoryTopImage.SetActive(v == 1);
			killAssistLogV1.SetActive(false);
			killAssistLogV2.SetActive(false);
			if (v == 1)
			{
				killAssistLogV1.SetActive(true);
			}
			else
			{
				killAssistLogV2.SetActive(true);
			}
		}

		private int GetBattleHudVersion()
		{
			if (!PlayerPrefs.HasKey(key))
			{
				PlayerPrefs.SetInt(key, 2);
			}
			return PlayerPrefs.GetInt(key);
		}

		private void Update()
		{
			if (InputManager.GetActionKeyDown(BattleActions.CHANGEHUD) && !battleChatInput.activeSelf)
			{
				SwitchHud();
			}
		}
	}
}
