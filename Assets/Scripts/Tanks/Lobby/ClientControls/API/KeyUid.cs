using System;

namespace Tanks.Lobby.ClientControls.API
{
	public class KeyUid : IComparable<KeyUid>
	{
		public string key;

		public string uid;

		public bool Equals(KeyUid other)
		{
			return string.Equals(key, other.key) && string.Equals(uid, other.uid);
		}

		public int CompareTo(KeyUid other)
		{
			return string.Compare(key, other.key, StringComparison.Ordinal);
		}

		public override bool Equals(object obj)
		{
			if (object.ReferenceEquals(null, obj))
			{
				return false;
			}
			return obj is KeyUid && Equals((KeyUid)obj);
		}

		public override int GetHashCode()
		{
			return (((key != null) ? key.GetHashCode() : 0) * 397) ^ ((uid != null) ? uid.GetHashCode() : 0);
		}
	}
}
