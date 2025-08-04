using Xunit;

namespace UnitTesting.XUnitTests
{
	public class CalculatorXUnitTests
	{
		private Calculator calculator;
		
		public CalculatorXUnitTests()
		{
			// Arrange
			calculator = new();
		}

		[Fact]
		public void Add_InputTwoInt_GetCorrectAddition()
		{
			// Arrange
			
			// Act
			int sum = calculator.Add(1, 2);

			// Assert
			Assert.Equal(3, sum);
		}

		[Theory]
		[InlineData(1)]
		[InlineData(3)]
		[InlineData(5)]
		[InlineData(7)]
		[InlineData(9)]
		public void IsOddNumberChecker_InputOddNumber_ReturnTrue(int num)
		{
			// Arrange
			
			// Act
			bool isOddNumber = calculator.IsOddNumber(num);

			// Assert
			Assert.True(isOddNumber);
		}

		[Fact]
		public void IsOddNumberChecker_InputEvenNumber_ReturnFalse()
		{
			// Arrange

			// Act
			bool isOddNumber = calculator.IsOddNumber(2);

			// Assert
			Assert.False(isOddNumber);
		}

		[Theory]
		[InlineData(1, true)]
		[InlineData(2, false)]
		public void IsOddNumberChecker_InputNumber_ReturnTrueIfOdd(int num, bool expectedResult)
		{
			// Arrange

			// Act
			var result = calculator.IsOddNumber(num);

			// Assert
			Assert.Equal(expectedResult, result);
		}

		[Theory]
		[InlineData(5.4, 10.5, 15.9)]
		[InlineData(5.43, 10.53, 15.9599)]
		[InlineData(5.49, 10.59, 16.08)]
		public void Add_InputTwoDouble_GetCorrectAddition(double a, double b, double expectedResult)
		{
			// Arrange

			// Act
			var sum =  calculator.Add(a, b);

			// Assert
			Assert.Equal(expectedResult, sum, 1);
		}

		[Fact]
		public void GetOddNumbersFromRange_InputRange_OutputValidOddNumbersFromProvidedRange()
		{
			// Arrange
			List<int> expectedResult = new List<int>() { 5, 7, 9 };

			// Act
			var actualResult = calculator.GetOddNumbersFromRange(5, 10);

			// Assert
			Assert.Equivalent(expectedResult, actualResult);
			Assert.Contains(7, actualResult);

			Assert.NotEmpty(actualResult);
			Assert.Equal(3, actualResult.Count);
			Assert.DoesNotContain(6, actualResult);
			Assert.Equal(actualResult.OrderBy(i => i), actualResult);
			//Assert.Equal(actualResult.OrderByDescending(i => i), actualResult);
		}
	}
}