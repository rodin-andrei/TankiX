using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientGarage.Impl;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class OpenLobbyButtonComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI _buttonText;

		[SerializeField]
		private LocalizedField _openText;

		[SerializeField]
		private LocalizedField _openTooltipText;

		[SerializeField]
		private LocalizedField _shareTooltipText;

		[SerializeField]
		private TooltipShowBehaviour _tooltip;

		[SerializeField]
		private GaragePrice _price;

		private long _lobbyId;

		public long LobbyId
		{
			get
			{
				return _lobbyId;
			}
			set
			{
				_lobbyId = value;
				_buttonText.text = _lobbyId.ToString();
				_tooltip.TipText = _shareTooltipText;
			}
		}

		public int Price
		{
			set
			{
				_price.transform.parent.gameObject.SetActive(value > 0);
				_price.SetPrice(0, value);
			}
		}

		public void ResetButtonText()
		{
			_buttonText.text = _openText;
			_tooltip.TipText = _openTooltipText;
		}
	}
}
