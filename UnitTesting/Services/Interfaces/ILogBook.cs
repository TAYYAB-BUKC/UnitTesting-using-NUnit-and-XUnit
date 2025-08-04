namespace UnitTesting.Services.Interfaces
{
	public interface ILogBook
	{
		void Log(string message);
		bool LogToDatabase(string message);
		bool LogBalanceAfterWithdrawal(decimal balance);
		string LogAndReturnMessage(string message);
	}
}