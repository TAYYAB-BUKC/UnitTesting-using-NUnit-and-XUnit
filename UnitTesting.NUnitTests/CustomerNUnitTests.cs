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
			string greetMessage = customer.GreetWithFullName("Ben", "Spark");

			// Assert
			ClassicAssert.AreEqual(greetMessage, "Hello, Ben Spark");
			Assert.That(greetMessage, Is.EqualTo("Hello, Ben Spark"));

			Assert.That(greetMessage, Does.StartWith("Hello"));
			Assert.That(greetMessage, Does.EndWith("Spark"));
			Assert.That(greetMessage, Does.Contain("Ben"));
			Assert.That(greetMessage, Does.Match("[A-Z]{1}[a-z]+, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
			Assert.That(greetMessage, Does.Contain("ben spark").IgnoreCase);
		}
	}
}