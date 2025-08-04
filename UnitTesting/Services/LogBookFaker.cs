using UnitTesting.Services.Interfaces;

namespace UnitTesting.Services
{
	public class LogBookFaker : ILogBook
	{
		public void Log(string message)
		{
			
		}

		public bool LogAndOutputMessage(string message, out string finalMessage)
		{
			finalMessage = message;
			return true;
		}

		public string LogAndReturnMessage(string message)
		{
			return message;
		}

		public bool LogBalanceAfterWithdrawal(decimal balance)
		{
			return true;
		}

		public bool LogToDatabase(string message)
		{
			return true;
		}
	}
}