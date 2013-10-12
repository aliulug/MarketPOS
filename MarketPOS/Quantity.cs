using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPOS.MarketPOS
{
	public class Quantity
	{
		private readonly int value;

		public Quantity(int qty)
		{
			this.value = qty;
		}

		public override string ToString()
		{
			return value.ToString();
		}

		public override bool Equals(object obj)
		{
			var otherQty = obj as Quantity;
			if (otherQty == null) return false;
			return value == otherQty.value;
		}

		public override int GetHashCode()
		{
			return value.GetHashCode();
		}
	}
}
