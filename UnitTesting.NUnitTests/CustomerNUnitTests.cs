using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace UnitTesting.NUnitTests
{
	[TestFixture]
	public class CustomerNUnitTests
	{
		private Customer customer;
		[SetUp]
		public void Setup()
		{
			// Arrange
			customer = new();
		}

		[Test]
		public void GreetWithFullName_InputFirstNameAndLastName_OutputGreetMessage()
		{
			// Arrange
			//Customer customer = new Customer();

			// Act
			customer.GreetWithFullName("Ben", "Spark");

			// Assert
			Assert.Multiple(() =>
			{
				ClassicAssert.AreEqual(customer.GreetMessage, "Hello, Ben Spark");
				Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Ben Spark"));

				Assert.That(customer.GreetMessage, Does.StartWith("Hello"));
				Assert.That(customer.GreetMessage, Does.EndWith("Spark"));
				Assert.That(customer.GreetMessage, Does.Contain("Ben"));
				Assert.That(customer.GreetMessage, Does.Match("[A-Z]{1}[a-z]+, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
				Assert.That(customer.GreetMessage, Does.Contain("ben spark").IgnoreCase);
			});
		}

		[Test]
		public void GreetMessage_OutputGreetMessageIsNull()
		{
			// Arrange
			//Customer customer = new Customer();

			// Act
			//customer.GreetWithFullName("Ben", "Spark");

			// Assert
			ClassicAssert.IsNull(customer.GreetMessage);
			Assert.That(customer.GreetMessage, Is.Null);
		}

		[Test]
		public void DiscountCheck_OutputDiscountShouldBeIn10To20Range()
		{
			// Arrange

			// Act

			// Assert
			Assert.That(customer.Discount, Is.InRange(10, 20));
		}

		[Test]
		public void GreetMessage_InputFirstNameOnly_OutputGreetMessageWithFirstNameOnly()
		{
			// Arrange

			// Act
			customer.GreetWithFullName("OnlyBen", "");

			// Assert
			ClassicAssert.IsNotNull(customer.GreetMessage);
			Assert.That(customer.GreetMessage, Is.Not.Null);
			ClassicAssert.IsFalse(string.IsNullOrEmpty(customer.GreetMessage));
		}

		[Test]
		public void GreetMessage_InputEmptyFirstName_OutputArgumentNullException()
		{
			// Arrange

			// Act & Assert
			var exception = ClassicAssert.Throws<ArgumentNullException>(()=> customer.GreetWithFullName("", "Spark"));
			ClassicAssert.AreEqual("Value cannot be null. (Parameter 'firstName')", exception.Message);
		}
	}
}