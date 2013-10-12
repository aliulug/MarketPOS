using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPOS.MarketPOS
{
	public class ItemId
	{
		private readonly string barcode;

		public ItemId(string barcode)
		{
			this.barcode = barcode;
		}

		public override bool Equals(object obj)
		{
			var other = obj as ItemId;
			if (other == null) return false;
			return this.barcode == other.barcode;
		}

		public override int GetHashCode()
		{
			return barcode.GetHashCode();
		}

		public override string ToString()
		{
			return barcode;
		}
	}
}
