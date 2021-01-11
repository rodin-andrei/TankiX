using UnityEngine;

namespace Tanks.Lobby.ClientEntrance.Impl
{
	public static class HardwareFingerprintUtils
	{
		private static string hardwareFingerprint;

		public static string HardwareFingerprint
		{
			get
			{
				return hardwareFingerprint ?? SystemInfo.deviceUniqueIdentifier;
			}
			set
			{
				hardwareFingerprint = value;
			}
		}
	}
}
