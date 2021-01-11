using System;
using UnityEngine;

namespace Lobby.ClientPayment.Impl
{
	public class Card
	{
		public string number;

		public string holderName;

		public string expiryMonth;

		public string expiryYear;

		public string cvc;

		public string generationtime;

		public override string ToString()
		{
			generationtime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
			return JsonUtility.ToJson(this);
		}
	}
}
