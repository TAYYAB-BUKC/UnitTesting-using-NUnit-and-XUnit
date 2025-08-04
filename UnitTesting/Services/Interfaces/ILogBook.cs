namespace UnitTesting.Services.Interfaces
{
	public interface ILogBook
	{
		int LogSeverity { get; set; }
		string LogType { get; set; }
		void Log(string message);
		bool LogToDatabase(string message);
		bool LogBalanceAfterWithdrawal(decimal balance);
		string LogAndReturnMessage(string message);
		bool LogAndOutputMessage(string message, out string finalMessage);
		bool LogWithRefObject(ref Customer customer);
	}
}