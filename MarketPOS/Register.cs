using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPOS.MarketPOS
{
	public class Register : ISaleEventListener
	{
		private readonly IReceiptReceiver receiptReceiver;
		private readonly IProductCatalog productCatalog;
		private Sale sale;

		public Register(IReceiptReceiver receiver, IProductCatalog productCatalog)
		{
			this.receiptReceiver = receiver;
			this.productCatalog = productCatalog;
		}

		public void SaleCompleted()
		{
			if (sale != null)
			{
				sale.SendReceiptTo(receiptReceiver);
			}
		}

		public void NewSaleInitiated()
		{
			sale = new Sale();
		}

		public void ItemEntered(ItemId itemId, Quantity quantity)
		{
			var productDescription = productCatalog.ProductDescriptionFor(itemId);
			sale.PurchaseItemWith(productDescription);
		}
	}

	public class Sale
	{
		private readonly List<ProductDescription> itemPurchased = new List<ProductDescription>();

		public void SendReceiptTo(IReceiptReceiver receiptReceiver)
		{
			var total = new Money(0m);
			itemPurchased.ForEach(item => total += item.UnitPrice);
			receiptReceiver.ReceiveTotalDue(total);
		}

		public void PurchaseItemWith(ProductDescription description)
		{
			itemPurchased.Add(description);
		}
	}
}
