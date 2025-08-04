namespace UnitTesting.Services.Interfaces
{
	public interface ILogBook
	{
		void Log(string message);
		bool LogToDatabase(string message);
		bool LogBalanceAfterWithdrawal(int balance);
	}
}