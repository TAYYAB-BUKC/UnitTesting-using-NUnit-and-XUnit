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
			Assert.That(series, Is.All.Member(0));
		}
	}
}