using Tanks.Lobby.ClientHangar.API;
using UnityEngine;

namespace Tanks.Lobby.ClientHangar.Impl
{
	public class HangarLocationBehaviour : MonoBehaviour
	{
		[SerializeField]
		private HangarLocation hangarLocation;

		public HangarLocation HangarLocation
		{
			get
			{
				return hangarLocation;
			}
		}
	}
}
