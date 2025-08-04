using Xunit;

namespace UnitTesting.XUnitTests
{
	public class FibonacciXUnitTests
	{
		private Fibonacci? fibonacci;
		
		public FibonacciXUnitTests()
		{
			// Arrange
			fibonacci = new Fibonacci();
		}

		[Fact]
		public void GetFibonacciSeries_InputRangeIs1_OutputFibonacciSeriesTillRange1()
		{
			// Arrange
			fibonacci!.Range = 1;

			// Act
			var series = fibonacci.GetFibonacciSeries();

			// Assert
			Assert.NotEmpty(series);
			Assert.Contains(0, series);
			Assert.True(series.SequenceEqual(new List<int> { 0 }));
		}

		[Fact]
		public void GetFibonacciSeries_InputRangeIs6_OutputFibonacciSeriesTillRange6()
		{
			// Arrange
			fibonacci!.Range = 6;
			var expectedResult = new List<int> { 0, 1, 1, 2, 3, 5 };
			// Act
			var series = fibonacci.GetFibonacciSeries();

			// Assert
			Assert.NotEmpty(series);
			Assert.Contains(3, series);
			Assert.Equal(6, series.Count);
			Assert.DoesNotContain(4, series);
			Assert.Equal(expectedResult, series);
			Assert.Equal(series.OrderBy(num => num), series);
		}
	}
}