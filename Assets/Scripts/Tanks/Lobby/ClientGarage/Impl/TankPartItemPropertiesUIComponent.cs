using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class TankPartItemPropertiesUIComponent : MonoBehaviour
	{
		[SerializeField]
		private UpgradePropertyUI propertyUIPreafab;
		[SerializeField]
		private RectTransform contentRect;
		[SerializeField]
		private RectTransform arrowImageRect;
		[SerializeField]
		private float minContentWidth;
		[SerializeField]
		private float maxContentWidth;
		[SerializeField]
		private SelectedItemUI selectedItemUI;
	}
}
