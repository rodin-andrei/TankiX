using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Steamworks;
using Tanks.Lobby.ClientEntrance.Impl;
using Tanks.Lobby.ClientNavigation.Impl;
using UnityEngine;

namespace Tanks.Lobby.ClientPayment.Impl
{
	public class SteamConnector : MonoBehaviour
	{
		private static bool initialized;

		private static SteamConnector instance;

		[SerializeField]
		private SteamComponent steamEntityBehaviourPrefab;

		private static SteamComponent steamComponent;

		protected static Callback<GetAuthSessionTicketResponse_t> GetAuthSessionTicketResponse;

		protected static Callback<MicroTxnAuthorizationResponse_t> MicroTxnAuthorizationResponse;

		protected static Callback<DlcInstalled_t> DlcInstalled;

		[Inject]
		public static EngineServiceInternal EngineService
		{
			get;
			set;
		}

		private static void OnMicroTxnAuthorizationResponse(MicroTxnAuthorizationResponse_t pCallback)
		{
			if (steamComponent != null)
			{
				MicroTxnAuthorizationResponseEvent eventInstance = new MicroTxnAuthorizationResponseEvent(pCallback);
				EngineService.Engine.ScheduleEvent(eventInstance, steamComponent.Entity);
			}
		}

		private static void OnGetAuthSessionTicketResponse(GetAuthSessionTicketResponse_t pCallback)
		{
			if (steamComponent != null)
			{
				steamComponent.OnGetAuthSessionTicketResponse(pCallback);
			}
		}

		private static void OnDlcInstalled(DlcInstalled_t pCallback)
		{
			if (steamComponent != null && !string.IsNullOrEmpty(SteamComponent.Ticket))
			{
				RequestCheckSteamDlcInstalledEvent eventInstance = new RequestCheckSteamDlcInstalledEvent();
				EngineService.Engine.ScheduleEvent(eventInstance, steamComponent.Entity);
			}
		}

		public void Start()
		{
			if (instance == null)
			{
				instance = this;
			}
			else
			{
				Object.Destroy(base.gameObject);
			}
			instance.Initialize();
		}

		private void Initialize()
		{
			if (SteamManager.Initialized)
			{
				SteamManager steamManager = Object.FindObjectOfType<SteamManager>();
				if (steamManager != null && steamManager.GetComponent<SkipRemoveOnSceneSwitch>() == null)
				{
					steamManager.gameObject.AddComponent<SkipRemoveOnSceneSwitch>();
				}
				if (!initialized)
				{
					initialized = true;
					GetAuthSessionTicketResponse = Callback<GetAuthSessionTicketResponse_t>.Create(OnGetAuthSessionTicketResponse);
					MicroTxnAuthorizationResponse = Callback<MicroTxnAuthorizationResponse_t>.Create(OnMicroTxnAuthorizationResponse);
					DlcInstalled = Callback<DlcInstalled_t>.Create(OnDlcInstalled);
				}
				if (steamComponent == null)
				{
					steamComponent = Object.Instantiate(steamEntityBehaviourPrefab);
					steamComponent.transform.SetParent(base.transform);
					steamComponent.GetTicket();
				}
			}
			else
			{
				Object.Destroy(this);
			}
		}
	}
}
