using System;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	[Serializable]
	public class LocalizedField
	{
		[SerializeField]
		private string uid;

		public string Value
		{
			get
			{
				return LocalizationUtils.Localize(uid).Replace("\\n", "\n");
			}
		}

		public string Uid
		{
			get
			{
				return uid;
			}
			set
			{
				uid = value;
			}
		}

		public static implicit operator string(LocalizedField field)
		{
			return field.Value;
		}
	}
}
