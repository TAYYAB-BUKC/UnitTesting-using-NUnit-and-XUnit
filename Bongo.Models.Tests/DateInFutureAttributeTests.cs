using Bongo.Models.ModelValidations;
using NUnit.Framework;

namespace Bongo.Models.Tests
{
	[TestFixture]
	public class DateInFutureAttributeTests
	{
		[Test]
		public void DateValidator_InputIsFutureDate_OutputIsValidDate()
		{
			// Arrange
			DateInFutureAttribute dateInFutureAttribute = new DateInFutureAttribute();

			// Act
			var isValidDate = dateInFutureAttribute.IsValid(DateTime.Now.AddDays(5));

			// Assert
			Assert.That(isValidDate, Is.True);
		}
	}
}