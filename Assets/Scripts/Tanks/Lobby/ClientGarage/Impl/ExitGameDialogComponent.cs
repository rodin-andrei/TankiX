using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ExitGameDialogComponent : BehaviourComponent
	{
		public GameObject content;
		public TextMeshProUGUI timer;
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
	}
}
