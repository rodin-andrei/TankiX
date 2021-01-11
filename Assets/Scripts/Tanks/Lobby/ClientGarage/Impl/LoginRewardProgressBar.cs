using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class LoginRewardProgressBar : MonoBehaviour
	{
		public enum FillType
		{
			Empty,
			Half,
			Full
		}

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

		public GameObject LeftLine
		{
			get
			{
				return leftLine.gameObject;
			}
		}

		public GameObject RightLine
		{
			get
			{
				return rightLine.gameObject;
			}
		}

		public void Fill(FillType type)
		{
			middleIcon.color = ((type != FillType.Half && type != FillType.Full) ? emptyColor : fillColor);
			leftLine.color = ((type != FillType.Half && type != FillType.Full) ? emptyColor : fillColor);
			rightLine.color = ((type != FillType.Full) ? emptyColor : fillColor);
		}
	}
}
