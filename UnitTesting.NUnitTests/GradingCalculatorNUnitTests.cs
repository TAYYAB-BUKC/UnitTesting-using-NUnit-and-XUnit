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

		[Test]
		public void GetGrade_InputScoreIs95AndAttendanIs65_OutputBGrade()
		{
			// Arrange
			gradingCalculator.Score = 95;
			gradingCalculator.AttendancePercentage = 65;

			// Act
			var grade = gradingCalculator.GetGrade();

			// Assert
			ClassicAssert.AreEqual("B", grade);
			Assert.That(grade, Is.EqualTo("B"));
			Assert.That(grade, Is.EqualTo("B").IgnoreCase);
		}

		[Test]
		[TestCase(95, 55)]
		[TestCase(65, 55)]
		[TestCase(50, 90)]
		public void GetGrade_InputScoreAndAttendan_OutputFGrade(int score, int attendance)
		{
			// Arrange
			gradingCalculator.Score = score;
			gradingCalculator.AttendancePercentage = attendance;

			// Act
			var grade = gradingCalculator.GetGrade();

			// Assert
			ClassicAssert.AreEqual("F", grade);
			Assert.That(grade, Is.EqualTo("F"));
			Assert.That(grade, Is.EqualTo("F").IgnoreCase);
		}

		[Test]
		[TestCase(95, 55, ExpectedResult = "F")]
		[TestCase(65, 55, ExpectedResult = "F")]
		[TestCase(50, 90, ExpectedResult = "F")]
		public string GetGrade_InputScoreAndAttendan_OutputFGrade_New(int score, int attendance)
		{
			// Arrange
			gradingCalculator.Score = score;
			gradingCalculator.AttendancePercentage = attendance;

			// Act & Assert
			return gradingCalculator.GetGrade();

			// Assert
			//ClassicAssert.AreEqual("F", grade);
			//Assert.That(grade, Is.EqualTo("F"));
			//Assert.That(grade, Is.EqualTo("F").IgnoreCase);
		}
	}
}