using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class TopPanelButton : MonoBehaviour
	{
		[SerializeField]
		private Image filledImage;

		private bool activated;

		public bool ImageFillToRight
		{
			set
			{
				filledImage.fillOrigin = ((!value) ? 1 : 0);
			}
		}

		public bool Activated
		{
			set
			{
				activated = value;
				GetComponent<Animator>().SetBool("activated", activated);
			}
		}

		private void OnEnable()
		{
			Activated = activated;
		}

		private void OnDisable()
		{
			Activated = false;
		}
	}
}
