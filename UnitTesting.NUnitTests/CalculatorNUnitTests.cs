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

		[Test]
		[TestCase(5.4, 10.5, ExpectedResult = 15.9)]
		[TestCase(5.43, 10.53, ExpectedResult = 15.959999999999999)]
		[TestCase(5.49, 10.59, ExpectedResult = 16.08)]
		public double Add_InputTwoDouble_GetCorrectAddition(double a, double b)
		{
			// Arrange
			Calculator calculator = new();

			// Act
			return calculator.Add(a, b);

			// Assert
			//ClassicAssert.AreEqual(15.9, sum, 1);
		}

		[Test]
		public void GetOddNumbersFromRange_InputRange_OutputValidOddNumbersFromProvidedRange()
		{
			// Arrange
			Calculator calculator = new();
			List<int> expectedResult = new List<int>() { 5, 7, 9 };

			// Act
			var actualResult = calculator.GetOddNumbersFromRange(5, 10);

			// Assert
			Assert.That(actualResult, Is.EquivalentTo(expectedResult));
		}
	}
}