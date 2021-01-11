using System;
using System.Security.Cryptography;
using System.Text;

namespace Tanks.Lobby.ClientEntrance.Impl
{
	public class PasswordSecurityUtils
	{
		private static SHA256Managed DIGEST = new SHA256Managed();

		public static byte[] RSAEncrypt(string publicKeyBase64, byte[] data)
		{
			using (RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider())
			{
				string[] array = publicKeyBase64.Split(new char[1]
				{
					':'
				}, 2);
				string xmlString = "<RSAKeyValue><Modulus>" + array[0] + "</Modulus><Exponent>" + array[1] + "</Exponent></RSAKeyValue>";
				rSACryptoServiceProvider.FromXmlString(xmlString);
				return rSACryptoServiceProvider.Encrypt(data, false);
			}
		}

		public static string RSAEncryptAsString(string publicKeyBase64, byte[] data)
		{
			return Convert.ToBase64String(RSAEncrypt(publicKeyBase64, data));
		}

		public static byte[] GetDigest(string data)
		{
			return DIGEST.ComputeHash(Encoding.UTF8.GetBytes(data));
		}

		public static string GetDigestAsString(string data)
		{
			return Convert.ToBase64String(DIGEST.ComputeHash(Encoding.UTF8.GetBytes(data)));
		}

		public static string GetDigestAsString(byte[] data)
		{
			return Convert.ToBase64String(DIGEST.ComputeHash(data));
		}

		public static string SaltPassword(string passcode, string password)
		{
			byte[] digest = GetDigest(password);
			byte[] b = Convert.FromBase64String(passcode);
			byte[] a = XorArrays(digest, b);
			return GetDigestAsString(ConcatenateArrays(a, digest));
		}

		private static byte[] ConcatenateArrays(byte[] a, byte[] b)
		{
			byte[] array = new byte[a.Length + b.Length];
			a.CopyTo(array, 0);
			b.CopyTo(array, a.Length);
			return array;
		}

		private static byte[] XorArrays(byte[] a, byte[] b)
		{
			if (a.Length == b.Length)
			{
				byte[] array = new byte[a.Length];
				for (int i = 0; i < a.Length; i++)
				{
					array[i] = (byte)(a[i] ^ b[i]);
				}
				return array;
			}
			throw new ArgumentException();
		}
	}
}
