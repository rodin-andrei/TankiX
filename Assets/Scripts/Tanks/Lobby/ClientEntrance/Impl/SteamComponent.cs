using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Steamworks;
using UnityEngine;

namespace Tanks.Lobby.ClientEntrance.Impl
{
	public class SteamComponent : ECSBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component, AttachToEntityListener
	{
		private float MIN_RETRY_DELAY = 10f;

		private static byte[] ticket;

		private static uint ticketLength;

		private float lastRequestTicketTime = -10f;

		private bool goToPayment;

		public Entity Entity
		{
			get;
			set;
		}

		public static string Ticket
		{
			get;
			private set;
		}

		public string SteamID
		{
			get
			{
				return SteamUser.GetSteamID().m_SteamID.ToString();
			}
		}

		public void GetTicket(bool goToPayment = false)
		{
			if (Time.unscaledTime - lastRequestTicketTime > MIN_RETRY_DELAY)
			{
				lastRequestTicketTime = Time.unscaledTime;
				this.goToPayment = goToPayment;
				if (SteamManager.Initialized && SteamAPI.IsSteamRunning())
				{
					ticket = new byte[1024];
					SteamUser.GetAuthSessionTicket(ticket, 1024, out ticketLength);
				}
			}
		}

		public void OnGetAuthSessionTicketResponse(GetAuthSessionTicketResponse_t pCallback)
		{
			Debug.Log("OnGetAuthSessionTicketResponse ");
			string text = string.Empty;
			for (int i = 0; i < ticketLength; i++)
			{
				text += string.Format("{0:X2}", ticket[i]);
			}
			Ticket = text;
			ScheduleEvent(new SteamAuthSessionRecievedEvent(), Entity);
		}

		public void AttachedToEntity(Entity entity)
		{
			Entity = entity;
		}
	}
}
