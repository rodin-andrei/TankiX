using Tanks.Lobby.ClientGarage.Impl;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	[RequireComponent(typeof(Button))]
	public class GoToShopButton : MonoBehaviour
	{
		[SerializeField]
		private int tab;

		[SerializeField]
		private BaseDialogComponent _callDialog;

		public int DesiredShopTab
		{
			get
			{
				return tab;
			}
			set
			{
				tab = value;
			}
		}

		public BaseDialogComponent CallDialog
		{
			get
			{
				return _callDialog;
			}
			set
			{
				_callDialog = value;
			}
		}

		private void Awake()
		{
			GetComponent<Button>().onClick.AddListener(Go);
		}

		private void Go()
		{
			MainScreenComponent.Instance.ShowShopIfNotVisible();
			ShopTabManager.shopTabIndex = tab;
			if (!(_callDialog == null))
			{
				_callDialog.Hide();
			}
		}
	}
}
