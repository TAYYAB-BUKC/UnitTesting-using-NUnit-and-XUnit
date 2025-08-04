using UnitTesting.Services.Interfaces;

namespace UnitTesting
{
	public class Customer : ICustomer
	{
		public int Discount { get; set; } = 10;
		public string? GreetMessage { get; set; }
		public int OrderTotal { get; set; }

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

		public CustomerType GetCustomerDetails()
		{
			if(OrderTotal < 100)
			{
				return new BasicCustomerType();
			}
			return new PlatinumCustomerType();
		}
	}
}