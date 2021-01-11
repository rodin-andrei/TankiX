using System.Collections.Generic;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientGarage.API;
using Tanks.Lobby.ClientUserProfile.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ExitGameDialogComponent : BehaviourComponent
	{
		public GameObject content;

		public TextMeshProUGUI timer;

		public List<DailyBonusData> dataList;

		public List<long> ReceivedRewards;

		[SerializeField]
		private GameObject ContainerView;

		[SerializeField]
		private GameObject DetailView;

		[SerializeField]
		private GameObject XCryView;

		[SerializeField]
		private GameObject CryView;

		[SerializeField]
		private GameObject EnergyView;

		[SerializeField]
		private GameObject row1;

		[SerializeField]
		private GameObject row2;

		public GameObject[] textNotReady;

		public GameObject textReady;

		public static GarageItemsRegistry GarageItemsRegistry
		{
			get;
			set;
		}

		public void InstantiateCryBonus(long amount)
		{
			GameObject gameObject = Object.Instantiate(CryView, row1.transform);
			gameObject.GetComponent<MultipleBonusView>().UpdateView(amount);
		}

		public void InstantiateXCryBonus(long amount)
		{
			GameObject gameObject = Object.Instantiate(XCryView, row1.transform);
			gameObject.GetComponent<MultipleBonusView>().UpdateView(amount);
		}

		public void InstantiateEnergyBonus(long amount)
		{
			GameObject gameObject = Object.Instantiate(EnergyView, row1.transform);
			gameObject.GetComponent<MultipleBonusView>().UpdateView(amount);
		}

		public void InstantiateDetailBonus(long marketItem)
		{
			GameObject gameObject = Object.Instantiate(DetailView, row1.transform);
			gameObject.GetComponent<DetailBonusView>().UpdateViewByMarketItem(marketItem);
			gameObject.GetComponent<Animator>().SetTrigger("show");
		}

		public void InstantiateContainerBonus(long marketItem)
		{
			GameObject gameObject = Object.Instantiate(ContainerView, row1.transform);
			gameObject.GetComponent<ContainerBonusView>().UpdateViewByMarketItem(marketItem);
			gameObject.GetComponent<Animator>().SetTrigger("show");
		}

		private void OnDisable()
		{
			row1.transform.DestroyChildren();
			row2.transform.DestroyChildren();
		}
	}
}
