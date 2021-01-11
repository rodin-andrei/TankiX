using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class LineSlotView : MonoBehaviour
	{
		[SerializeField]
		private Image longLine;

		[SerializeField]
		private Image shortLine;

		private void OnDisable()
		{
			longLine.fillAmount = 0f;
			shortLine.fillAmount = 0f;
		}
	}
}
