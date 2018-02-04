using ConsoleApp;

namespace UnitTests.Fake
{
	public class CryptoRandom2EqualsMock : ICryptoRandom
	{
		private readonly bool _isGet2Equals;
		private int _count = 0;
		private int _res = 0;

		public CryptoRandom2EqualsMock(bool isGet2Equals)
		{
			_isGet2Equals = isGet2Equals;
		}

		/// <summary>
		/// вернет 2 одинковых результата
		/// </summary>
		public int Next()
		{
			if (_isGet2Equals)
			{
				if (_count == 1)
				{
					_count++;
					return _res;
				}
			}
			_res++;
			_count++;

			return _res;
		}
	}
}