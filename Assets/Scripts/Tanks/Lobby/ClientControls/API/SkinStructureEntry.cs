using System;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	[Serializable]
	public class SkinStructureEntry
	{
		[SerializeField]
		private string name;

		[SerializeField]
		private string uid;

		[SerializeField]
		private string parentUid;

		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
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

		public string ParentUid
		{
			get
			{
				return parentUid;
			}
			set
			{
				parentUid = value;
			}
		}
	}
}
