using System;
using System.Security.Cryptography;

namespace ConsoleApp
{
	public class CryptoRandom : ICryptoRandom
	{
		private RNGCryptoServiceProvider _rng = new RNGCryptoServiceProvider();
		private byte[] _uint32Buffer = new byte[4];

		public Int32 Next()
		{
			_rng.GetBytes(_uint32Buffer);
			return BitConverter.ToInt32(_uint32Buffer, 0) & 0x7FFFFFFF;
		}
	}
}