using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class UpgradeStars : MonoBehaviour
	{
		[SerializeField]
		private Image[] stars;

		public void SetPower(float power)
		{
			if (power < 0f)
			{
				base.gameObject.SetActive(false);
				return;
			}
			base.gameObject.SetActive(true);
			Image[] array = stars;
			foreach (Image image in array)
			{
				float num = 1f / (float)stars.Length;
				float num2 = Mathf.Min(num, power);
				power -= num2;
				image.fillAmount = num2 / num;
			}
		}
	}
}
