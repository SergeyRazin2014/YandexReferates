using ConsoleApp.Infrastructura;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
	[TestFixture]
    public class ValidatorTest
    {
		[TestCase("1")]
		[TestCase("0")]
		[TestCase("1000")]
		public void IsIntTest_WhenTrue(string str)
		{
			Assert.True( new Validator().IsPositiveInt(str));
		}

		[TestCase("")]
		[TestCase(null)]
		[TestCase("-1")]
		[TestCase("hello")]
		[TestCase("*+-")]
		public void IsIntTest_WhenFalse(string str)
		{
			Assert.False(new Validator().IsPositiveInt(str));
		}
    }
}
