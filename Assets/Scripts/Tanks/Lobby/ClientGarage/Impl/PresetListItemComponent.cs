using Platform.Kernel.ECS.ClientEntitySystem.API;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class PresetListItemComponent : UIBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private GameObject iconObject;

		[SerializeField]
		private TextMeshProUGUI text;

		[SerializeField]
		private Graphic bgGraphic;

		[SerializeField]
		private Color lockedColor;

		[SerializeField]
		private Color unlockedColor;

		private int rank;

		private bool locked;

		public Entity Preset
		{
			get;
			set;
		}

		public bool IsUserItem
		{
			get;
			set;
		}

		public bool IsOwned
		{
			get;
			set;
		}

		public string PresetName
		{
			get
			{
				return text.text;
			}
			set
			{
				text.text = value;
			}
		}

		public int Rank
		{
			get
			{
				return rank;
			}
			set
			{
				rank = value;
			}
		}

		public bool Locked
		{
			get
			{
				return locked;
			}
			set
			{
				locked = value;
				iconObject.SetActive(value);
				bgGraphic.color = ((!value) ? unlockedColor : lockedColor);
			}
		}
	}
}
