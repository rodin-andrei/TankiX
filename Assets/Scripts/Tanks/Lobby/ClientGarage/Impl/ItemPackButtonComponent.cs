using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ItemPackButtonComponent : BehaviourComponent
	{
		[SerializeField]
		private int count;

		public int Count
		{
			get
			{
				return count;
			}
			set
			{
				count = value;
			}
		}
	}
}
