using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientQuests.Impl
{
	public class QuestItemGUITextComponent : LocalizedControl
	{
		[SerializeField]
		private TextMeshProUGUI progress;
		[SerializeField]
		private TextMeshProUGUI pickUp;
		[SerializeField]
		private TextMeshProUGUI nextQuest;
	}
}
