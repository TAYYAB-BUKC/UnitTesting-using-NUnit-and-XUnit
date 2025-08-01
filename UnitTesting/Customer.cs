namespace UnitTesting
{
	public class Customer
	{
		public string? GreetMessage { get; set; }

		public string GreetWithFullName(string firstName, string lastName)
		{
			return GreetMessage = $"Hello, {firstName} {lastName}";
		}
	}
}