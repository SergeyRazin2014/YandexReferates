using ConsoleApp.Infrastructura;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.Fake;
using NSubstitute;
using ConsoleApp;

namespace UnitTests
{
	[TestFixture]
	public class ReferatHelperTest
	{


		[Test]
		public void GetRandomReferatesTokensTest_When_RandomGet2EqualsResult()
		{
			var random = new CryptoRandom2EqualsMock(true);

			var downloadedReferates = new List<int> { 111, 222, 333 };
			var res = new ReferatHelper(2, downloadedReferates, random).GetRandomReferatesTokens();

			var expect = new List<int> { 1, 2 };

			CollectionAssert.AreEqual(expect, res);

		}

		[Test]
		public void GetRandomReferatesTokensTest_When_RandomGetNotEqualsResult()
		{
			var random = new CryptoRandom2EqualsMock(false);

			var downloadedReferates = new List<int> { 111, 222, 333 };
			var res = new ReferatHelper(2, downloadedReferates, random).GetRandomReferatesTokens();

			var expect = new List<int> { 1, 2 };

			CollectionAssert.AreEqual(expect, res);

		}

		[Test]
		public void GetReferatTextFromHtmlTest()
		{
			var random = new CryptoRandom2EqualsMock(false);

			var downloadedReferates = new List<int> { 111, 222, 333 };

			var html = "<div><p>pam-pam</p><div class=\"referats__text\">Hello world</div></div>";

			var res = new ReferatHelper(2, downloadedReferates, random).GetReferatTextFromHtml(html);

			Assert.AreEqual("Hello world", res);



		}
	}
}
