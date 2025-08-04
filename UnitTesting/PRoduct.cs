using UnitTesting.Services.Interfaces;

namespace UnitTesting
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }

		public double GetPrice(Customer customer)
		{
			if (customer.GetCustomerDetails() is PlatinumCustomerType)
			{
				return Price * 0.8;
			}
			return Price;
		}

		public double GetPrice(ICustomer customer)
		{
			if (customer.OrderTotal > 100)
			{
				return Price * 0.8;
			}
			return Price;
		}
	}
}