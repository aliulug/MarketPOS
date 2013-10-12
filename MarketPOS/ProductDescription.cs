using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPOS.MarketPOS
{
	public class ProductDescription
	{
		private string _productDescription;
		private Money _money;

		public ProductDescription(string description, Money money)
		{
			_productDescription = description;
			_money = money;
		}

		public Money UnitPrice
		{
			get { return _money; }
		}
	}
}
