using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPOS.MarketPOS
{
	public class Money
	{
		private readonly decimal amount;

		public Money(decimal value)
		{
			this.amount = value;
		}

		public static Money operator +(Money money1, Money money2)
		{
			return new Money(money1.amount + money2.amount);
		}

		public override string ToString()
		{
			return amount.ToString();
		}

		public override bool Equals(object obj)
		{
			var otherAmount = obj as Money;
			if (otherAmount == null) return false;
			return amount == otherAmount.amount;
		}

		public override int GetHashCode()
		{
			return amount.GetHashCode();
		}
	}
}