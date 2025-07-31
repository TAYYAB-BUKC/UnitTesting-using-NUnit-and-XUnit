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
	}
}