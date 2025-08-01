using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace UnitTesting.NUnitTests
{
	[TestFixture]
	public class CustomerNUnitTests
	{
		[Test]
		public void GreetWithFullName_InputFirstNameAndLastName_OutputGreetMessage()
		{
			// Arrange
			Customer customer = new Customer();

			// Act
			customer.GreetWithFullName("Ben", "Spark");

			// Assert
			ClassicAssert.AreEqual(customer.GreetMessage, "Hello, Ben Spark");
			Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Ben Spark"));

			Assert.That(customer.GreetMessage, Does.StartWith("Hello"));
			Assert.That(customer.GreetMessage, Does.EndWith("Spark"));
			Assert.That(customer.GreetMessage, Does.Contain("Ben"));
			Assert.That(customer.GreetMessage, Does.Match("[A-Z]{1}[a-z]+, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
			Assert.That(customer.GreetMessage, Does.Contain("ben spark").IgnoreCase);
		}

		[Test]
		public void GreetMessage_OutputGreetMessageIsNull()
		{
			// Arrange
			Customer customer = new Customer();

			// Act
			//customer.GreetWithFullName("Ben", "Spark");

			// Assert
			ClassicAssert.IsNull(customer.GreetMessage);
			Assert.That(customer.GreetMessage, Is.Null);
		}
	}
}