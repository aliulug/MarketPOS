using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketPOS.MarketPOS;
using NMock2;
using NUnit.Framework;

//
namespace MarketPOS.Tests
{
	[TestFixture]
	public class CommandParserTests
	{
		private Mockery mockery;
		private CommandParser commandParser;
		private ISaleEventListener saleEventListener;

		[SetUp]
		public void BeforeTest()
		{
			mockery = new Mockery();
			saleEventListener = mockery.NewMock<ISaleEventListener>();
			commandParser = new CommandParser(saleEventListener);
		}

		[TearDown]
		public void AfterTest()
		{
			mockery.VerifyAllExpectationsHaveBeenMet();
		}

		[Test]
		public void NotifiesListenerOfNewSaleEvent()
		{
			var newSaleCommand = "Command:NewSale";
			Expect.Once.On(saleEventListener).Method("NewSaleInitiated");
			Expect.e
			commandParser.Parse(newSaleCommand);
		}

		[Test]
		public void NotifiesListenerOfSaleCompletedEvent()
		{
			var endSaleCommand = "Command:EndSale";
			Expect.Once.On(saleEventListener).Method("SaleCompleted");	
			commandParser.Parse(endSaleCommand);
		}

		[Test]
		public void NotifiesListenerOfItemAndQuantityEntered()
		{
			var message = "Input: Barcode=100008888559, Quantity=1";
			var expectedItemid = new ItemId("100008888559");
			var expectedQuantity = new Quantity(1);
			Expect.Once.On(saleEventListener).Method("ItemEntered").With(expectedItemid, expectedQuantity);
			commandParser.Parse(message);
		}
	}
}
