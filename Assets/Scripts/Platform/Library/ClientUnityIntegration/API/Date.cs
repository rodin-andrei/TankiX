using System;
using System.Runtime.InteropServices;
using Platform.Kernel.OSGi.ClientCore.API;
using UnityEngine;

namespace Platform.Library.ClientUnityIntegration.API
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct Date : IComparable<Date>
	{
		[Inject]
		public static UnityTime Time
		{
			get;
			set;
		}

		public float UnityTime
		{
			get;
			set;
		}

		public static Date Now
		{
			get
			{
				return new Date(Time.realtimeSinceStartup);
			}
		}

		public Date(float unityTime)
		{
			this = default(Date);
			UnityTime = unityTime;
		}

		public static float FromServerTime(long diffToServer, long serverTime)
		{
			long num = serverTime - diffToServer;
			return (float)num / 1000f;
		}

		public long ToServerTime(long diffToServer)
		{
			return (long)(UnityTime * 1000f) + diffToServer;
		}

		public Date AddSeconds(float seconds)
		{
			return new Date(UnityTime + seconds);
		}

		public Date AddMilliseconds(long milliseconds)
		{
			return new Date(UnityTime + (float)milliseconds / 1000f);
		}

		public float GetProgress(Date beginDate, Date endDate)
		{
			return GetProgress(beginDate, endDate - beginDate);
		}

		public float GetProgress(Date beginDate, float durationSeconds)
		{
			float num = UnityTime - beginDate.UnityTime;
			return Mathf.Clamp01(num / durationSeconds);
		}

		public static Date operator +(Date self, float seconds)
		{
			return new Date(self.UnityTime + seconds);
		}

		public static Date operator -(Date self, float seconds)
		{
			return new Date(self.UnityTime - seconds);
		}

		public static float operator -(Date self, Date other)
		{
			return self.UnityTime - other.UnityTime;
		}

		public static bool operator ==(Date t1, Date t2)
		{
			return t1.UnityTime == t2.UnityTime;
		}

		public static bool operator !=(Date t1, Date t2)
		{
			return t1.UnityTime != t2.UnityTime;
		}

		public static bool operator <(Date t1, Date t2)
		{
			return t1.UnityTime < t2.UnityTime;
		}

		public static bool operator <=(Date t1, Date t2)
		{
			return t1.UnityTime <= t2.UnityTime;
		}

		public static bool operator >(Date t1, Date t2)
		{
			return t1.UnityTime > t2.UnityTime;
		}

		public static bool operator >=(Date t1, Date t2)
		{
			return t1.UnityTime >= t2.UnityTime;
		}

		public override int GetHashCode()
		{
			return UnityTime.GetHashCode();
		}

		public int CompareTo(Date other)
		{
			return UnityTime.CompareTo(other.UnityTime);
		}

		public override string ToString()
		{
			return UnityTime.ToString();
		}
	}
}
