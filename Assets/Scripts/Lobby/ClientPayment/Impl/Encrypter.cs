using System;
using System.Text;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;

namespace Lobby.ClientPayment.Impl
{
	public class Encrypter
	{
		public const string PREFIX = "adyenc#";

		public const string VERSION = "0_1_15";

		public const string SEPARATOR = "$";

		private string publicKey;

		private CcmBlockCipher aesCipher;

		private IBufferedCipher rsaCipher;

		public Encrypter(string publicKey)
		{
			this.publicKey = publicKey;
			InitializeRSA();
		}

		private void InitializeRSA()
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Expected O, but got Unknown
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Expected O, but got Unknown
			string[] array = publicKey.Split('|');
			BigInteger val = new BigInteger(array[1].ToLower(), 16);
			BigInteger val2 = new BigInteger(array[0].ToLower(), 16);
			RsaKeyParameters val3 = new RsaKeyParameters(false, val, val2);
			rsaCipher = CipherUtilities.GetCipher("RSA/None/PKCS1Padding");
			rsaCipher.Init(true, (ICipherParameters)(object)val3);
		}

		public string Encrypt(string data)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Expected O, but got Unknown
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Expected O, but got Unknown
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Expected O, but got Unknown
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Expected O, but got Unknown
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Expected O, but got Unknown
			SecureRandom val = new SecureRandom();
			byte[] array = new byte[32];
			((Random)(object)val).NextBytes(array);
			byte[] array2 = new byte[12];
			((Random)(object)val).NextBytes(array2);
			byte[] inArray = rsaCipher.DoFinal(array);
			byte[] bytes = Encoding.UTF8.GetBytes(data);
			AeadParameters val2 = new AeadParameters(new KeyParameter(array), 64, array2, new byte[0]);
			aesCipher = new CcmBlockCipher((IBlockCipher)new AesFastEngine());
			aesCipher.Init(true, (ICipherParameters)(object)val2);
			byte[] array3 = new byte[aesCipher.GetOutputSize(bytes.Length)];
			int num = aesCipher.ProcessBytes(bytes, 0, bytes.Length, array3, 0);
			aesCipher.DoFinal(array3, num);
			byte[] array4 = new byte[array2.Length + array3.Length];
			Buffer.BlockCopy(array2, 0, array4, 0, array2.Length);
			Buffer.BlockCopy(array3, 0, array4, array2.Length, array3.Length);
			return "adyenc#0_1_15$" + Convert.ToBase64String(inArray) + "$" + Convert.ToBase64String(array4);
		}
	}
}
