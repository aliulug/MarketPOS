using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketPOS.MarketPOS;
using NMock2;
using NUnit.Framework;

namespace MarketPOS.Tests
{
	[TestFixture]
	public class RegisterTests
	{
		private Mockery mockery;
		private IReceiptReceiver receiptReceiver;
		private Register register;
		private readonly ItemId itemId_1 = new ItemId("000000001");
		private readonly ItemId itemId_2 = new ItemId("000000002");
		private readonly ProductDescription descriptionForItemWithId1 = new ProductDescription("description 1", new Money(3.00m));
		private readonly ProductDescription descriptionForItemWithId2 = new ProductDescription("description 2", new Money(7.00m));
		private readonly Quantity single_item = new Quantity(1);
		private IProductCatalog productCatalog;

		[SetUp]
		public void BeforeTest()
		{
			mockery = new Mockery();
			receiptReceiver = mockery.NewMock<IReceiptReceiver>();
			productCatalog = mockery.NewMock<IProductCatalog>();
			register = new Register(receiptReceiver, productCatalog);
			Stub.On(productCatalog).Method("ProductDescriptionFor").With(itemId_1).Will(Return.Value(descriptionForItemWithId1));
			Stub.On(productCatalog).Method("ProductDescriptionFor").With(itemId_2).Will(Return.Value(descriptionForItemWithId2));
		}

		[TearDown]
		public void AfterTest()
		{
			mockery.VerifyAllExpectationsHaveBeenMet();
		}

		[Test]
		public void ReceiptTotalForASaleWithNoItemsShouldBeZero()
		{
			var receiptReceiver = mockery.NewMock<IReceiptReceiver>();
			var register = new Register(receiptReceiver, productCatalog);
			register.NewSaleInitiated();
			var totalDue = new Money(0m);
			Expect.Once.On(receiptReceiver).Method("ReceiveTotalDue").With(totalDue);
			register.SaleCompleted();
		}

		[Test]
		public void ShouldNotCalculateRecieptWhenThereIsNoSale()
		{
			Expect.Never.On(receiptReceiver);
			register.SaleCompleted();
		}

		[Test]
		public void ShouldCalculateRecieptForSaleWithMultipleItemsOfSingleQuantity()
		{
			register.NewSaleInitiated();
			register.ItemEntered(itemId_1, single_item);
			register.ItemEntered(itemId_2, single_item);
			Expect.Once.On(receiptReceiver).Method("ReceiveTotalDue").With(new Money(10.00m));
			register.SaleCompleted();
		}
	}
}
