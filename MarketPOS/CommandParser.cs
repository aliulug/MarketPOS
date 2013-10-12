using System.Collections.Generic;

namespace MarketPOS.MarketPOS
{
	public class CommandParser
	{
		private const string END_SALE_COMMAND = "EndSale";
		private readonly ISaleEventListener saleEventListener;
		private const string INPUT = "Input";
		private const string START_SALE_COMMAND = "NewSale";

		public CommandParser(ISaleEventListener saleEventListener)
		{
			this.saleEventListener = saleEventListener;
		}

		public void Parse(string messageFromDevice)
		{
			var command = messageFromDevice.Split(':');
			var commandType = command[0].Trim();
			var commandBody = command[1].Trim();
			if (INPUT.Equals(commandType))
			{
				ProcessInputCommand(commandBody);
			}
			else
			{
				ProcessCommand(commandBody);
			}
		}

		private void ProcessCommand(string commandBody)
		{
			if (END_SALE_COMMAND.Equals(commandBody)) saleEventListener.SaleCompleted();
			else if (START_SALE_COMMAND.Equals(commandBody)) saleEventListener.NewSaleInitiated();
		}

		private void ProcessInputCommand(string commandBody)
		{
			var arguments = new Dictionary<string, string>();
			var commandArgs = commandBody.Split(',');
			foreach (var argument in commandArgs)
			{
				var argNameValues = argument.Split('=');
				arguments.Add(argNameValues[0].Trim(), argNameValues[1].Trim());
			}
			saleEventListener.ItemEntered(new ItemId(arguments["Barcode"]), new Quantity(int.Parse(arguments["Quantity"])));
		}
	}
}
