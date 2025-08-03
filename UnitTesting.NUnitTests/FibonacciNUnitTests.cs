using NUnit.Framework;

namespace UnitTesting.NUnitTests
{
	[TestFixture]
	public class FibonacciNUnitTests
	{
		private Fibonacci? fibonacci;
		[SetUp]
		public void SetUp()
		{
			// Arrange
			fibonacci = new Fibonacci();
		}

		[Test]
		public void GetFibonacciSeries_InputRangeIs1_OutputFibonacciSeriesTillRange1()
		{
			// Arrange
			fibonacci!.Range = 1;

			// Act
			var series = fibonacci.GetFibonacciSeries();

			// Assert
			Assert.That(series, Is.Not.Empty);
			Assert.That(series, Is.Ordered);
			Assert.That(series, Has.Member(0));
		}

		[Test]
		public void GetFibonacciSeries_InputRangeIs6_OutputFibonacciSeriesTillRange6()
		{
			// Arrange
			fibonacci!.Range = 6;
			var expectedResult = new List<int> { 0, 1, 1, 2, 3, 5 };
			// Act
			var series = fibonacci.GetFibonacciSeries();

			// Assert
			Assert.That(series, Does.Contain(3));
			Assert.That(series.Count, Is.EqualTo(6));
			Assert.That(series, Has.No.Member(4));
			Assert.That(series, Is.EquivalentTo(expectedResult));
		}
	}
}