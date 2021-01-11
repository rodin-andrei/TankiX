using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Battle.ClientCore.Impl;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Battle.ClientCore.API
{
	[SerialVersionUID(635890692253926600L)]
	public class BattleLabelComponent : EntityBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private long battleId;

		[SerializeField]
		private GameObject map;

		[SerializeField]
		private GameObject mode;

		[SerializeField]
		private GameObject battleIcon;

		public long BattleId
		{
			get
			{
				return battleId;
			}
			set
			{
				battleId = value;
				base.gameObject.AddComponent<BattleLabelReadyComponent>();
			}
		}

		public string Map
		{
			get
			{
				return map.GetComponent<Text>().text;
			}
			set
			{
				map.GetComponent<Text>().text = value;
				map.SetActive(true);
			}
		}

		public string Mode
		{
			get
			{
				return mode.GetComponent<Text>().text;
			}
			set
			{
				mode.GetComponent<Text>().text = value;
				mode.SetActive(true);
			}
		}

		public bool BattleIconActivity
		{
			get
			{
				return battleIcon.activeSelf;
			}
			set
			{
				battleIcon.SetActive(value);
			}
		}
	}
}
