using Tanks.Lobby.ClientSettings.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public class ObjectDeactivator : MonoBehaviour
	{
		public Quality.QualityLevel maxQualityForDeactivating;

		private void Awake()
		{
			int qualityLevel = QualitySettings.GetQualityLevel();
			if (qualityLevel <= (int)maxQualityForDeactivating)
			{
				base.gameObject.SetActive(false);
			}
		}
	}
}
