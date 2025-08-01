using NUnit.Framework;

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
			string greetMessage = customer.GreetWithFullName("Ben", "Spark");

			// Assert
			Assert.That(greetMessage, Is.EqualTo("Hello, Ben Spark"));
		}
	}
}