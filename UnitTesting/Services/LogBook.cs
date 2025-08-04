using UnitTesting.Services.Interfaces;

namespace UnitTesting.Services
{
	public class LogBook : ILogBook
	{
		public void Log(string message)
		{
			Console.WriteLine(message);
		}

		public bool LogAndOutputMessage(string message, out string finalMessage)
		{
			finalMessage = $"Hello, {message}";
			return true;
		}

		public string LogAndReturnMessage(string message)
		{
			Console.WriteLine(message);
			return message;
		}

		public bool LogBalanceAfterWithdrawal(decimal balance)
		{
			if (balance >= 0)
			{
				Console.WriteLine("Success");
				return true;
			}
			Console.WriteLine("Failed");
			return false;
		}

		public bool LogToDatabase(string message)
		{
			Console.WriteLine($"{message}");
			return true;
		}
	}
}