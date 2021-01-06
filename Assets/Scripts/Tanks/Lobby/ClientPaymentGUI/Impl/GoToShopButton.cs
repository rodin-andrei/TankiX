using UnityEngine;
using Tanks.Lobby.ClientGarage.Impl;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class GoToShopButton : MonoBehaviour
	{
		[SerializeField]
		private int tab;
		[SerializeField]
		private BaseDialogComponent _callDialog;
	}
}
