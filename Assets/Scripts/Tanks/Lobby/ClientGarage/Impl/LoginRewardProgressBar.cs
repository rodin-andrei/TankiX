using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class LoginRewardProgressBar : MonoBehaviour
	{
		[SerializeField]
		private Image middleIcon;
		[SerializeField]
		private Image leftLine;
		[SerializeField]
		private Image rightLine;
		[SerializeField]
		private Color fillColor;
		[SerializeField]
		private Color emptyColor;
	}
}
