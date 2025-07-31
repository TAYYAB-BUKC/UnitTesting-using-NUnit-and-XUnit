namespace UnitTesting.MSTests
{
	[TestClass]
	public class CalculatorMSTests
	{
		[TestMethod]
		public void Add_InputTwoInt_GetCorrectAddition()
		{
			// Arrange
			Calculator calculator = new();

			// Act
			int sum = calculator.Add(1, 2);

			// Assert
			Assert.AreEqual(3, sum);
		}
	}
}