using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using TMPro;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class BattleSeriesUiComponent : BehaviourComponent
	{
		[SerializeField]
		private Color _battleSeriesColor;
		[SerializeField]
		private Color _deserterColor;
		[SerializeField]
		private Color _defaultColor;
		[SerializeField]
		private LocalizedField _battlesAmountSingularText;
		[SerializeField]
		private LocalizedField _battlesAmountPlural1Text;
		[SerializeField]
		private LocalizedField _battlesAmountPlural2Text;
		[SerializeField]
		private TextMeshProUGUI _battleSeriesText;
		[SerializeField]
		private LocalizedField _battleSeriesString;
		[SerializeField]
		private LocalizedField _deserterString;
		[SerializeField]
		private TextMeshProUGUI _additionalExpText;
		[SerializeField]
		private LocalizedField _additionalExpString;
		[SerializeField]
		private TextMeshProUGUI _additionScoresText;
		[SerializeField]
		private LocalizedField _additionScoresString;
		[SerializeField]
		private TextMeshProUGUI _additionalMessageText;
		[SerializeField]
		private LocalizedField _nextBattleNotificationString;
		[SerializeField]
		private LocalizedField _maxSeriesAchiviedString;
		[SerializeField]
		private LocalizedField _deserterAdditionalMessageString;
		[SerializeField]
		private TextMeshProUGUI _battleSeriesCountText;
		[SerializeField]
		private ImageSkin _battleSeriesImage;
		[SerializeField]
		private string[] _battleImageUids;
		[SerializeField]
		private string _deserterImageUid;
	}
}
