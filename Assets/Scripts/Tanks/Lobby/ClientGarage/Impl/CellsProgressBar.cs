using System.Collections.Generic;
using System.Linq;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientUserProfile.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class CellsProgressBar : MonoBehaviour
	{
		public GameObject emptyCell;

		public GameObject filledCell;

		public GameObject filledEpicCell;

		public void Init(int capacity, DailyBonusData[] bonusData, List<long> receivedRewards)
		{
			base.transform.DestroyChildren();
			foreach (long receivedReward in receivedRewards)
			{
				DailyBonusData bonusData2 = getBonusData(receivedReward, bonusData);
				CreateFromPrefab((!bonusData2.IsEpic()) ? filledCell : filledEpicCell);
			}
			int num = capacity - receivedRewards.Count;
			for (int i = 0; i < num; i++)
			{
				CreateFromPrefab(emptyCell);
			}
		}

		private void CreateFromPrefab(GameObject prefab)
		{
			GameObject gameObject = Object.Instantiate(prefab);
			gameObject.transform.SetParent(base.transform, false);
		}

		private DailyBonusData getBonusData(long receivedReward, DailyBonusData[] bonusData)
		{
			return bonusData.First((DailyBonusData it) => it.Code == receivedReward);
		}

		private void OnDisable()
		{
			base.transform.DestroyChildren();
		}
	}
}
