using System.Collections.Generic;
using System.Runtime.InteropServices;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.ECS.ClientEntitySystem.Impl;
using Platform.Kernel.OSGi.ClientCore.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientGarage.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class SummaryBonusComponent : LocalizedControl, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct MapKey
		{
			public long MarketItem
			{
				get;
				set;
			}
		}

		private Dictionary<MapKey, StaticBonusUI> effectToInstance = new Dictionary<MapKey, StaticBonusUI>();

		[SerializeField]
		private List<StaticBonusUI> bonuses = new List<StaticBonusUI>();

		private int usedBonuses;

		[SerializeField]
		private Text totalBonusText;

		[Inject]
		public new static EngineService EngineService
		{
			get;
			set;
		}

		public string TotalBonusText
		{
			set
			{
				totalBonusText.text = value;
			}
		}

		protected override void Awake()
		{
			base.Awake();
			if (usedBonuses == 0)
			{
				base.gameObject.SetActive(false);
			}
		}

		private void OnDisable()
		{
			foreach (StaticBonusUI bonuse in bonuses)
			{
				bonuse.gameObject.SetActive(false);
			}
			effectToInstance.Clear();
			usedBonuses = 0;
			base.gameObject.SetActive(false);
		}

		private static string GetItemIcon(long marketItem)
		{
			string empty = string.Empty;
			Entity entity = Flow.Current.EntityRegistry.GetEntity(marketItem);
			return entity.GetComponent<ItemIconComponent>().SpriteUid;
		}
	}
}
