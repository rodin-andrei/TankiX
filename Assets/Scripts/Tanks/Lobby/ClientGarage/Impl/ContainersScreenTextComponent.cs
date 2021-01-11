using Tanks.Lobby.ClientNavigation.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ContainersScreenTextComponent : LocalizedScreenComponent
	{
		[SerializeField]
		private Text containersButtonText;

		[SerializeField]
		private Text openContainerButtonText;

		[SerializeField]
		private Text openAllContainerButtonText;

		[SerializeField]
		private Text emptyListText;

		public virtual string ContainersButtonText
		{
			set
			{
				containersButtonText.text = value;
			}
		}

		public virtual string OpenContainerButtonText
		{
			set
			{
				openContainerButtonText.text = value;
			}
		}

		public virtual string OpenAllContainerButtonText
		{
			set
			{
				openAllContainerButtonText.text = value;
			}
		}

		public virtual string EmptyListText
		{
			set
			{
				emptyListText.text = value;
			}
		}
	}
}
