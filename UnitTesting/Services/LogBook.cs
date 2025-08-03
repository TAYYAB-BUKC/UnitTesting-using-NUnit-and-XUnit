using UnitTesting.Services.Interfaces;

namespace UnitTesting.Services
{
	public class LogBook : ILogBook
	{
		public void Log(string message)
		{
			Console.WriteLine(message);
		}
	}
}