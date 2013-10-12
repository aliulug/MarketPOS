namespace MarketPOS.MarketPOS
{
	public interface ISaleEventListener
	{
		void SaleCompleted();
		void NewSaleInitiated();
		void ItemEntered(ItemId itemId, Quantity quantity);
	}
}
