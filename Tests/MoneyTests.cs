using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketPOS.MarketPOS;
using NUnit.Framework;

namespace MarketPOS.Tests
{
	[TestFixture]
	public class MoneyTest
	{
		[Test]
		public void ShouldBeAbleToCreateTheSumOfTwoAmounts()
		{
			var twoDollars = new Money(2.00m);
			var threeDollars = new Money(3m);
			var fiveDollars = new Money(5m);
			Assert.That(twoDollars + threeDollars, Is.EqualTo(fiveDollars));
		}
	}
}
