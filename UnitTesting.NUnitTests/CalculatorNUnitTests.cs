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
		[TestCase(1)]
		[TestCase(3)]
		[TestCase(5)]
		[TestCase(7)]
		[TestCase(9)]
		public void IsOddNumberChecker_InputOddNumber_ReturnTrue(int num)
		{
			// Arrange
			Calculator calculator = new();

			// Act
			bool isOddNumber = calculator.IsOddNumber(num);

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

		[Test]
		[TestCase(1, ExpectedResult = true)]
		[TestCase(2, ExpectedResult = false)]
		public bool IsOddNumberChecker_InputNumber_ReturnTrueIfOdd(int num)
		{
			// Arrange
			Calculator calculator = new();

			// Act & Assert
			return calculator.IsOddNumber(num);
		}
	}
}