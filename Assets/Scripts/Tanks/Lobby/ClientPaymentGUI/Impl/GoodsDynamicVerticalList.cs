using UnityEngine;
using System;
using Tanks.Lobby.ClientControls.API;
using System.Collections.Generic;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class GoodsDynamicVerticalList : MonoBehaviour
	{
		[Serializable]
		public class ItemContent
		{
			public RectTransform Prefab;
			public int Height;
		}

		[Serializable]
		public class ContentAdapter
		{
			public GoodsDynamicVerticalList.ItemContent Content;
			public CommentedListDataProvider DataProvider;
		}

		[Serializable]
		public class GoodsContentAdapter : ContentAdapter
		{
			public GoodsDynamicVerticalList.GoodsType Type;
		}

		public enum GoodsType
		{
			XCrystals = 0,
			SpecialOffer = 1,
		}

		[SerializeField]
		private GameObject commentPrefab;
		[SerializeField]
		private RectTransform item;
		[SerializeField]
		private List<GoodsDynamicVerticalList.GoodsContentAdapter> Adapters;
		[SerializeField]
		private int spacing;
		[SerializeField]
		private RectTransform viewport;
	}
}
