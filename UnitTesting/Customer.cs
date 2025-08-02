namespace UnitTesting
{
	public class Customer
	{
		public int Discount { get; set; } = 10;
		public string? GreetMessage { get; set; }

		public string GreetWithFullName(string firstName, string lastName)
		{
			if (string.IsNullOrWhiteSpace(firstName))
			{
				throw new ArgumentNullException(nameof(firstName));
			}

			GreetMessage = $"Hello, {firstName} {lastName}";
			Discount = 20;
			return GreetMessage;
		}
	}
}