using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class BattleItemContentComponent : UIBehaviour
	{
		[SerializeField]
		private Text battleModeTextField;
		[SerializeField]
		private Text debugInfoTextField;
		[SerializeField]
		private Text timeTextField;
		[SerializeField]
		private Text userCountTextField;
		[SerializeField]
		private Text scoreTextField;
		[SerializeField]
		private RawImage previewImage;
		[SerializeField]
		private Animator animator;
		[SerializeField]
		private Material grayscaleMaterial;
		[SerializeField]
		private RectTransform timeTransform;
		[SerializeField]
		private RectTransform scoreTransform;
		[SerializeField]
		private RectTransform scoreTankIcon;
		[SerializeField]
		private RectTransform scoreFlagIcon;
	}
}
