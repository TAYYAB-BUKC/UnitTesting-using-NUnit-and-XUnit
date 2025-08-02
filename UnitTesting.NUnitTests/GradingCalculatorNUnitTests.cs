using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace UnitTesting.NUnitTests
{
	[TestFixture]
	public class GradingCalculatorNUnitTests
	{
		private GradingCalculator gradingCalculator;
		[SetUp]
		public void SetUp()
		{
			gradingCalculator = new();
		}

		[Test]
		public void GetGrade_InputScoreIs95AndAttendanIs90_OutputAGrade()
		{
			// Arrange
			gradingCalculator.Score = 95;
			gradingCalculator.AttendancePercentage = 90;

			// Act
			var grade = gradingCalculator.GetGrade();

			// Assert
			ClassicAssert.AreEqual("A", grade);
			Assert.That(grade, Is.EqualTo("A"));
			Assert.That(grade, Is.EqualTo("A").IgnoreCase);
		}
	}
}