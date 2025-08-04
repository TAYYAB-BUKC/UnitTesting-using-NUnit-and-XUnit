namespace UnitTesting.Services.Interfaces
{
	public interface ICustomer
	{
		int Discount { get; set; }
		string? GreetMessage { get; set; }
		int OrderTotal { get; set; }
	
		string GreetWithFullName(string firstName, string lastName);
		CustomerType GetCustomerDetails();
	}
}