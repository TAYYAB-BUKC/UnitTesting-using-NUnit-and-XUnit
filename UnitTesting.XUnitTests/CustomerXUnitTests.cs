using Xunit;

namespace UnitTesting.XUnitTests
{
	public class CustomerXUnitTests
	{
		private Customer customer;
		public CustomerXUnitTests()
		{
			// Arrange
			customer = new();
		}

		[Fact]
		public void GreetWithFullName_InputFirstNameAndLastName_OutputGreetMessage()
		{
			// Arrange

			// Act
			customer.GreetWithFullName("Ben", "Spark");

			// Assert
			Assert.Multiple(() =>
			{
				Assert.Equal("Hello, Ben Spark", customer.GreetMessage);
				Assert.StartsWith("Hello", customer.GreetMessage);
				Assert.EndsWith("Spark", customer.GreetMessage);
				Assert.Contains("Ben", customer.GreetMessage);
				Assert.Matches("[A-Z]{1}[a-z]+, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", customer.GreetMessage);
				Assert.Contains("BEN SPark".ToLower(), customer.GreetMessage.ToLower());
				Assert.DoesNotContain("ben1 spark1".ToLower(), customer.GreetMessage.ToLower());
			});
		}

		[Fact]
		public void GreetMessage_OutputGreetMessageIsNull()
		{
			// Arrange

			// Act

			// Assert
			Assert.Null(customer.GreetMessage);
		}

		[Fact]
		public void DiscountCheck_OutputDiscountShouldBeIn10To20Range()
		{
			// Arrange

			// Act

			// Assert
			Assert.InRange(customer.Discount, 10, 20);
		}

		[Fact]
		public void GreetMessage_InputFirstNameOnly_OutputGreetMessageWithFirstNameOnly()
		{
			// Arrange

			// Act
			customer.GreetWithFullName("OnlyBen", "");

			// Assert
			Assert.NotNull(customer.GreetMessage);
			Assert.False(string.IsNullOrEmpty(customer.GreetMessage));
		}

		[Fact]
		public void GreetMessage_InputEmptyFirstName_OutputArgumentNullException()
		{
			// Arrange

			// Act & Assert
			var exception = Assert.Throws<ArgumentNullException>(() => customer.GreetWithFullName("", "Spark"));
			Assert.Equal("Value cannot be null. (Parameter 'firstName')", exception.Message);

			Assert.Throws<ArgumentNullException>(() => customer.GreetWithFullName("", "Spark"));
		}

		[Fact]
		public void GreetMessage_InputEmptyFirstName_OutputArgumentNullException_New()
		{
			// Arrange

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => customer.GreetWithFullName("", ""));
		}

		[Fact]
		public void GetCustomerType_InputCutomerWithLessThan100Orders_OutputTypeIsBasicCustomer()
		{
			// Arrange
			customer.OrderTotal = 10;

			// Act 
			var customerType = customer.GetCustomerDetails();

			//Assert
			Assert.IsType<BasicCustomerType>(customerType);
		}

		[Fact]
		public void GetCustomerType_InputCutomerWithMoreThan100Orders_OutputTypeIsPlatinumCustomer()
		{
			// Arrange
			customer.OrderTotal = 210;

			// Act 
			var customerType = customer.GetCustomerDetails();

			//Assert
			Assert.IsType<PlatinumCustomerType>(customerType);
		}
	}
}