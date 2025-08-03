namespace UnitTesting
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }

		public double GetPrice(Customer customer)
		{
			if(customer.GetCustomerDetails() == default(PlatinumCustomerType))
			{
				return Price * 0.8;
			}
			return Price;
		}
	}
}