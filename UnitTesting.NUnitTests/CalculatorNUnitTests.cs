using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace UnitTesting.NUnitTests
{
	[TestFixture]
	public class CalculatorNUnitTests
	{
		[Test]
		public void Add_InputTwoInt_GetCorrectAddition()
		{
			// Arrange
			Calculator calculator = new();

			// Act
			int sum = calculator.Add(1, 2);

			// Assert
			ClassicAssert.AreEqual(3, sum);
		}

		[Test]
		public void IsOddNumberChecker_InputOddNumber_ReturnTrue()
		{
			// Arrange
			Calculator calculator = new();

			// Act
			bool isOddNumber = calculator.IsOddNumber(1);

			// Assert
			ClassicAssert.That(isOddNumber, Is.True);
			//ClassicAssert.IsTrue(isOddNumber);
		}

		[Test]
		public void IsOddNumberChecker_InputEvenNumber_ReturnFalse()
		{
			// Arrange
			Calculator calculator = new();

			// Act
			bool isOddNumber = calculator.IsOddNumber(2);

			// Assert
			ClassicAssert.That(isOddNumber, Is.False);
			//ClassicAssert.IsFalse(isOddNumber);
		}
	}
}