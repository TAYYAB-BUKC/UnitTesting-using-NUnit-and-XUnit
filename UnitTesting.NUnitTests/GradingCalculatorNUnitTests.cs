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

		[Test]
		public void GetGrade_InputScoreIs85AndAttendanIs90_OutputBGrade()
		{
			// Arrange
			gradingCalculator.Score = 85;
			gradingCalculator.AttendancePercentage = 90;

			// Act
			var grade = gradingCalculator.GetGrade();

			// Assert
			ClassicAssert.AreEqual("B", grade);
			Assert.That(grade, Is.EqualTo("B"));
			Assert.That(grade, Is.EqualTo("B").IgnoreCase);
		}

		[Test]
		public void GetGrade_InputScoreIs65AndAttendanIs90_OutputCGrade()
		{
			// Arrange
			gradingCalculator.Score = 65;
			gradingCalculator.AttendancePercentage = 90;

			// Act
			var grade = gradingCalculator.GetGrade();

			// Assert
			ClassicAssert.AreEqual("C", grade);
			Assert.That(grade, Is.EqualTo("C"));
			Assert.That(grade, Is.EqualTo("C").IgnoreCase);
		}
	}
}