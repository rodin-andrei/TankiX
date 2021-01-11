using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientHangar.Impl
{
	public class CardsContainerSoundsComponent : BehaviourComponent
	{
		[SerializeField]
		private CardsSoundBehaviour cardsSounds;

		public CardsSoundBehaviour CardsSounds
		{
			get
			{
				return cardsSounds;
			}
		}
	}
}
