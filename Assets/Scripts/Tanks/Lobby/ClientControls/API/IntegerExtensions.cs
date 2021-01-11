using System;
using Platform.Library.ClientLocale.API;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public static class IntegerExtensions
	{
		public static string ToStringSeparatedByThousands(this int value)
		{
			return value.ToString("N0", LocaleUtils.GetCulture());
		}

		public static string ToStringSeparatedByThousands(this long value)
		{
			return value.ToString("N0", LocaleUtils.GetCulture());
		}

		public static string ToStringSeparatedByThousands(this double value)
		{
			if (Math.Abs(value - (double)(int)value) < (double)Mathf.Epsilon)
			{
				return value.ToString("N0", LocaleUtils.GetCulture());
			}
			return value.ToString("N2", LocaleUtils.GetCulture());
		}
	}
}
