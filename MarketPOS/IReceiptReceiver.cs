using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPOS.MarketPOS
{
	public interface IReceiptReceiver
	{
		void ReceiveTotalDue(Money amount);
	}
}
